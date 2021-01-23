    using EnvDTE;
    using System;
    using System.Management;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text.RegularExpressions;
    
    namespace ImplemenationCTestTestAdapter
    {
        /// <remarks>
        ///  Taken from here: https://github.com/getgauge/gauge-visualstudio/blob/master/Gauge.VisualStudio/Helpers/DTEHelper.cs
        ///         and here: https://github.com/smkanadl/CTestTestAdapter/blob/master/ImplemenationCTestTestAdapter/DTEHelper.cs
        /// </remarks>
        internal static class DteHelper
        {
            [DllImport("ole32.dll")]
            private static extern int CreateBindCtx(uint reserved, out IBindCtx ppbc);
    
            private static readonly Regex DteRegex = new Regex(@"!\S+\.DTE\.[\d\.]+:\d+");
    
            internal static DTE GetCurrent(IServiceProvider serviceProvider = null)
            {
                if (serviceProvider != null)
                {
                    return (DTE) serviceProvider.GetService(typeof (DTE));
                }
                var currentProcess = System.Diagnostics.Process.GetCurrentProcess();
                var vsProcessId = GetVisualStudioProcessId(currentProcess.Id);
                object runningObject = null;
                IBindCtx bindCtx = null;
                IRunningObjectTable rot = null;
                IEnumMoniker enumMonikers = null;
                try
                {
                    Marshal.ThrowExceptionForHR(CreateBindCtx(0, out bindCtx));
                    bindCtx.GetRunningObjectTable(out rot);
                    rot.EnumRunning(out enumMonikers);
                    var moniker = new IMoniker[1];
                    var numberFetched = IntPtr.Zero;
                    while (enumMonikers.Next(1, moniker, numberFetched) == 0)
                    {
                        var runningObjectMoniker = moniker[0];
                        string name = null;
                        try
                        {
                            runningObjectMoniker?.GetDisplayName(bindCtx, null, out name);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            // do nothing.
                        }
                        if (string.IsNullOrEmpty(name) || !DteRegex.IsMatch(name))
                        {
                            continue;
                        }
                        if (!name.EndsWith(vsProcessId.ToString()))
                        {
                            continue;
                        }
                        rot.GetObject(runningObjectMoniker, out runningObject);
                        break;
                    }
                }
                finally
                {
                    if (enumMonikers != null)
                    {
                        Marshal.ReleaseComObject(enumMonikers);
                    }
                    if (rot != null)
                    {
                        Marshal.ReleaseComObject(rot);
                    }
                    if (bindCtx != null)
                    {
                        Marshal.ReleaseComObject(bindCtx);
                    }
                }
                return (DTE) runningObject;
            }
    
            private static int GetVisualStudioProcessId(int testRunnerProcessId)
            {
                var mos =
                    new ManagementObjectSearcher($"Select * From Win32_Process Where ProcessID={testRunnerProcessId}");
                var processes =
                    mos.Get().Cast<ManagementObject>().Select(mo => Convert.ToInt32(mo["ParentProcessID"])).ToList();
                if (processes.Any())
                {
                    return processes.First();
                }
                return -1;
            }
        }
    }
