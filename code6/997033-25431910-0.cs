    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ProcessWatcher {
        public class Program {
            private static WatcherThread watcher;
            /// <summary>
            /// Application entry point
            /// </summary>
            /// <param name="args">Command-line parameters</param>
            static void Main(string[] args) {
                // args = new string[] { "mpc-hc", "" };
                if (args.Length < 2) {
                    System.Windows.Forms.MessageBox.Show(
    @"Call with these parameters
    ProcessWatcher [WatchProcess] [HostProcess] [Interval]
    [WatchProcess]: Name of the process to monitor and kill if frozen.
    [HostProcess]: When specified host process stops, end program.
    [Interval]: (optional) Interval in milliseconds between checks. Default is 2000.
    Example:
    ProcessWatcher mpc-hc NaturalGroundingPlayer 2000");
                    return;
                }
                string WatchProcess = args[0];
                string HostProcess = args[1];
                int Interval = args.Length > 2 ? Int32.Parse(args[2]) : 2000;
                watcher = new WatcherThread(WatchProcess, HostProcess, Interval);
                System.Windows.Forms.Application.Run();
            }
        }
    }
