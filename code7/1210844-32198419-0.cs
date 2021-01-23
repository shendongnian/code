    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace CPUUsage
    {
        class Program
    {
        static void Main(string[] args)
        {
            var status = new CPUStatus(System.Diagnostics.Process.GetCurrentProcess());
            Console.WriteLine("CPU usage: {0}", status.RawUsage);
            var processes = System.Diagnostics.Process.GetProcessesByName("devenv");
            if (processes.Any())
            {
                var status2 = new CPUStatus(processes.First());
                Console.WriteLine("Devenv CPU usage: {0}", status.RawUsage);
                Thread.Sleep(1000);
                Console.WriteLine("Devenv CPU usage: {0}", status.RawUsage);
            }
        }
    }
    /// <summary>
    /// Class to retrieve the CPU values.
    /// </summary>
    /// <remarks></remarks>
    public class CPUStatus
    {
        #region "Members"
        private ProcessTimes _ProcessTimes = new ProcessTimes();
        private long _OldUserTime;
        private long _OldKernelTime;
        private DateTime _OldUpdate;
        private Int32 _RawUsage;        
        private object _Lock = new object();
        private IntPtr _processHandle;
        #endregion
        #region "Constructor"
        /// <summary>
        /// Initializes the CPUStatus instance
        /// </summary>
        /// <param name="process">The process to monitor</param>
        public CPUStatus(System.Diagnostics.Process process)
        {
            _OldUpdate = DateTime.MinValue;          
            _processHandle = process.Handle;
            InitValues();
        }
        #endregion
        #region Imports
        [DllImport("kernel32.dll", SetLastError = true)]
        [return:MarshalAs(UnmanagedType.Bool)]
        static extern bool GetProcessTimes(IntPtr hProcess, out long lpCreationTime, out long lpExitTime, out long lpKernelTime, out long lpUserTime);
        #endregion
        #region "Private methods"
        /// <summary>
        /// Retrieve the initial values
        /// </summary>
        /// <remarks></remarks>
        private void InitValues()
        {
            try
            {
                if ((GetProcessTimes(_processHandle, out _ProcessTimes.RawCreationTime, out _ProcessTimes.RawExitTime, out _ProcessTimes.RawKernelTime, out _ProcessTimes.RawUserTime)))
                {
                    // convert the values to DateTime values
                    _ProcessTimes.ConvertTime();
                    _OldUserTime = _ProcessTimes.UserTime.Ticks;
                    _OldKernelTime = _ProcessTimes.KernelTime.Ticks;
                    _OldUpdate = DateTime.Now;
                }
            }
            catch (Exception)
            {
                _OldUpdate = DateTime.MinValue;
            }
        }
        /// <summary>
        /// Refreshes the usage values
        /// </summary>
        /// <remarks></remarks>
        private void Refresh()
        {
            lock (_Lock)
            {
                if ((GetProcessTimes(_processHandle, out _ProcessTimes.RawCreationTime, out _ProcessTimes.RawExitTime, out _ProcessTimes.RawKernelTime, out _ProcessTimes.RawUserTime)))
                {
                    // convert the values to DateTime values
                    _ProcessTimes.ConvertTime();
                    UpdateCPUUsage(_ProcessTimes.UserTime.Ticks, _ProcessTimes.KernelTime.Ticks);
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "Could not retrieve process times");
                }
            }
        }
        /// <summary>
        /// updates the cpu usage (cpu usgae = UserTime + KernelTime)
        /// </summary>
        /// <param name="newUserTime"></param>
        /// <param name="newKernelTime"></param>
        /// <remarks></remarks>
        private void UpdateCPUUsage(long newUserTime, long newKernelTime)
        {
            long UpdateDelay = 0;
            long UserTime = newUserTime - _OldUserTime;
            long KernelTime = newKernelTime - _OldKernelTime;
            if (_OldUpdate == DateTime.MinValue)
            {
                _RawUsage = Convert.ToInt32((UserTime + KernelTime) * 100);
            }
            else
            {
                // eliminates "divided by zero"
                if (DateTime.Now.Ticks == _OldUpdate.Ticks)
                    Thread.Sleep(100);
                UpdateDelay = DateTime.Now.Ticks - _OldUpdate.Ticks;
                _RawUsage = Convert.ToInt32(((UserTime + KernelTime) * 100) / UpdateDelay);
            }
            _OldUserTime = newUserTime;
            _OldKernelTime = newKernelTime;
            _OldUpdate = DateTime.Now;
        }
        #endregion
        #region "Properties"
        /// <summary>
        /// Gets the CPU usage
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public Int32 RawUsage
        {
            get
            {
                lock (_Lock)
                {
                    Refresh();
                    return _RawUsage;
                }
            }
        }
        #endregion
        #region "internal classes"
        private struct ProcessTimes
        {
            public DateTime CreationTime;
            public DateTime ExitTime;
            public DateTime KernelTime;
            public DateTime UserTime;
            public long RawCreationTime;
            public long RawExitTime;
            public long RawKernelTime;
            public long RawUserTime;
            public void ConvertTime()
            {
                CreationTime = FiletimeToDateTime(RawCreationTime);
                ExitTime = FiletimeToDateTime(RawExitTime);
                KernelTime = FiletimeToDateTime(RawKernelTime);
                UserTime = FiletimeToDateTime(RawUserTime);
            }
            private DateTime FiletimeToDateTime(long FileTime)
            {
                try
                {
                    return DateTime.FromFileTimeUtc(FileTime);
                }
                catch (Exception)
                {
                    return new DateTime();
                }
            }
        }
        #endregion
    }
    }
