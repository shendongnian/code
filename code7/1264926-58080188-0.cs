    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace Utilities.UI
    {
        /// <summary>
        /// WinFormsAppIdleHandler implements a WinForms Render Loop (max FPS possible).
        /// Reference: http://blogs.msdn.com/b/tmiller/archive/2005/05/05/415008.aspx
        /// </summary>
        public sealed class WinFormsAppIdleHandler
        {
            private readonly object _completedEventLock = new object();
            private event EventHandler _applicationLoopDoWork;
    
            //PRIVATE Constructor
            private WinFormsAppIdleHandler()
            {
                Enabled = false;
                SleepTime = 10;
                Application.Idle += Application_Idle;
            }
    
            /// <summary>
            /// Singleton from:
            /// http://csharpindepth.com/Articles/General/Singleton.aspx
            /// </summary>
            private static readonly Lazy<WinFormsAppIdleHandler> lazy = new Lazy<WinFormsAppIdleHandler>(() => new WinFormsAppIdleHandler());
            public static WinFormsAppIdleHandler Instance { get { return lazy.Value; } }
    
            /// <summary>
            /// Gets or sets if must fire ApplicationLoopDoWork event.
            /// </summary>
            public bool Enabled { get; set; }
    
            /// <summary>
            /// Gets or sets the minimum time betwen ApplicationLoopDoWork fires.
            /// </summary>
            public int SleepTime { get; set; }
    
            /// <summary>
            /// Fires while the UI is free to work. Sleeps for "SleepTime" ms.
            /// </summary>
            public event EventHandler ApplicationLoopDoWork
            {
                //Reason of using locks:
                //http://stackoverflow.com/questions/1037811/c-thread-safe-events
                add
                {
                    lock (_completedEventLock)
                        _applicationLoopDoWork += value;
                }
    
                remove
                {
                    lock (_completedEventLock)
                        _applicationLoopDoWork -= value;
                }
            }
    
            /// <summary>
            /// FINALMENTE! Imagem ao vivo sem travar! Muito bom!
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void Application_Idle(object sender, EventArgs e)
            {
                //Try to update interface
                while (Enabled && IsAppStillIdle())
                {
                    OnApplicationIdleDoWork(EventArgs.Empty);
                    //Give a break to the processor... :)
                    //8 ms -> 125 Hz
                    //10 ms -> 100 Hz
                    Thread.Sleep(SleepTime);
                }
            }
    
            private void OnApplicationIdleDoWork(EventArgs e)
            {
                var handler = _applicationLoopDoWork;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
    
            /// <summary>
            /// Gets if the app still idle.
            /// </summary>
            /// <returns></returns>
            private static bool IsAppStillIdle()
            {
                bool stillIdle = false;
                try
                {
                    Message msg;
                    stillIdle = !PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
                }
                catch (Exception e)
                {
                    //Should never get here... I hope...
                    MessageBox.Show("IsAppStillIdle() Exception. Message: " + e.Message);
                }
                return stillIdle;
            }
    
            #region  Unmanaged Get PeekMessage
            // http://blogs.msdn.com/b/tmiller/archive/2005/05/05/415008.aspx
            [System.Security.SuppressUnmanagedCodeSecurity] // We won't use this maliciously
            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            public static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);
    
            #endregion
        }
    }
