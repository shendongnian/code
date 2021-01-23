    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using System.Threading;
    namespace ProcessWatcher {
        /// <summary>
        /// Checks regularly whether specified process is responsive. If not, kill it.
        /// </summary>
        public class WatcherThread {
            private string processWatch;
            private string processHost;
            private Timer timer;
            public WatcherThread(string processWatch, string processHost, int interval) {
                this.processWatch = processWatch;
                this.processHost = processHost;
                timer = new Timer(KillIfFrozen, null, interval, interval);
            }
            /// <summary>
            /// Kills the watched process if it is not responsive.
            /// </summary>
            /// <param name="state">null</param>
            public void KillIfFrozen(Object state) {
                Process[] ProcessList = Process.GetProcessesByName(processWatch);
                foreach (Process item in ProcessList) {
                    if (item.Responding == false) {
                        // Wait 1500ms for the process to respond
                        for (int i = 0; i < 6; i++) {
                            Thread.Sleep(250);
                            if (item.Responding)
                                break;
                        }
                        // If still not responsive, kill process.
                        if (item.Responding == false) {
                            try {
                                // This throws an "Access denied" exception but still stops the process.
                                item.Kill();
                            } catch {}
                        }
                    }
                }
                // If host process is closed, end program.
                if (!string.IsNullOrEmpty(processHost)) {
                    ProcessList = Process.GetProcessesByName(processHost);
                    if (ProcessList.Length == 0) {
                        System.Windows.Forms.Application.Exit();
                    }
                }
            }
        }
    }
