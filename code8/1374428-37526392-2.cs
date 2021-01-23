    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    namespace CallBackFromCpp
    {
        public class WorkerClass
        {
            /// <summary>
            /// Usually a form or a winform control that implements "Invoke/BeginInvode"
            /// </summary>
            ContainerControl _sender = null;
            /// <summary>
            /// The delegate method (callback) on the sender to call
            /// </summary>
            Delegate _senderDelegate = null;
            public delegate void ReportProgressCallback(int percentage, string message);
            public delegate bool CancellationPendingCallback();
            [StructLayout(LayoutKind.Sequential)]
            public class WorkProgressInteropNegotiator
            {
                public ReportProgressCallback reportProgress;
                public CancellationPendingCallback cancellationPending;
    #pragma warning disable 0649
                // C# does not see this member is set up in native code, we disable warning to avoid it.
                public bool cancel;
    #pragma warning restore 0649
            }
            [DllImport("CppLayer.dll")]
            public static extern void CppLongFunction([In, Out] WorkProgressInteropNegotiator negotiator);
            /// <summary>
            /// Constructor called by calle using ThreadPool OR ThreadStart
            /// </summary>
            public WorkerClass(ContainerControl sender, Delegate senderDelegate)
            {
                _sender = sender;
                _senderDelegate = senderDelegate;
            }
            /// <summary>
            /// Method for ThreadStart delegate
            /// </summary>
            public void RunProcess()
            {
                Thread.CurrentThread.IsBackground = true; //make them a daemon
                WorkProgressInteropNegotiator negotiator = new WorkProgressInteropNegotiator();
                negotiator.reportProgress = new ReportProgressCallback(ReportProgress);
                negotiator.cancellationPending = new CancellationPendingCallback(() => { return Stop; });
                // Refer for details to
                // "How to: Marshal Callbacks and Delegates Using C++ Interop" 
                // http://msdn.microsoft.com/en-us/library/367eeye0%28v=vs.100%29.aspx
                GCHandle gch = GCHandle.Alloc(negotiator);
                CppLongFunction(negotiator);
                gch.Free();
            }
            private void ReportProgress(int progressPercentage, string message)
            {
                _sender.BeginInvoke(_senderDelegate, new object[] { progressPercentage, message });
            }
            volatile bool _stop = false;
            public bool Stop
            {
                set 
                {
                     _stop = value;
                }
                get
                {
                    return _stop;
                }
            }
        }
    }
