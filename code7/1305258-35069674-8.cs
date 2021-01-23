    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using EnvDTE;
    
    namespace Common
    {
    
        [ComImport, Guid("00000016-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IOleMessageFilter
        {
            [PreserveSig]
            int HandleInComingCall(int dwCallType, IntPtr hTaskCaller, int dwTickCount, IntPtr lpInterfaceInfo);
    
            [PreserveSig]
            int RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType);
    
            [PreserveSig]
            int MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType);
        }
    
        public class MessageFilter : IOleMessageFilter
        {
            private const int Handled = 0, RetryAllowed = 2, Retry = 99, Cancel = -1, WaitAndDispatch = 2;
    
            int IOleMessageFilter.HandleInComingCall(int dwCallType, IntPtr hTaskCaller, int dwTickCount, IntPtr lpInterfaceInfo)
            {
                return Handled;
            }
    
            int IOleMessageFilter.RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType)
            {
                return dwRejectType == RetryAllowed ? Retry : Cancel;
            }
    
            int IOleMessageFilter.MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType)
            {
                return WaitAndDispatch;
            }
    
            public static void Register()
            {
                CoRegisterMessageFilter(new MessageFilter());
            }
    
            public static void Revoke()
            {
                CoRegisterMessageFilter(null);
            }
    
            private static void CoRegisterMessageFilter(IOleMessageFilter newFilter)
            {
                IOleMessageFilter oldFilter;
                CoRegisterMessageFilter(newFilter, out oldFilter);
            }
    
            [DllImport("Ole32.dll")]
            private static extern int CoRegisterMessageFilter(IOleMessageFilter newFilter, out IOleMessageFilter oldFilter);
        }
    
        public static class AttachDebugger
        {
            public static void ToProcess(int processId)
            {
                MessageFilter.Register();
                var process = GetProcess(processId);
                if (process != null)
                {
                    process.Attach();
                    Console.WriteLine("Attached to {0}", process.Name);
                }
                MessageFilter.Revoke();
            }
            private static Process GetProcess(int processID)
            {
                var dte = (DTE)Marshal.GetActiveObject("VisualStudio.DTE.12.0");
                var processes = dte.Debugger.LocalProcesses.OfType<Process>();
                return processes.SingleOrDefault(x => x.ProcessID == processID);
            }
        }
    }
