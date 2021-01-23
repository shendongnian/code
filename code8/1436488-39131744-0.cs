    using System;
    using System.Timers;
    using System.Windows.Forms;
    namespace SONotify
    {
        class Program
        {
            private static System.Timers.Timer _timer;
            private static NotifyIcon _notify;
            static void Main(string[] args)
            {
                Console.WriteLine("Press enter to exit");
                SetIcon();
                SetTimer();
    
                Application.Run();
                Console.ReadLine();
                _timer.Stop();
                _timer.Dispose();
            }
            private static void SetIcon()
            {
                _notify = new NotifyIcon();
                _notify.Icon = new System.Drawing.Icon("icon.ico");
                _notify.Click += NotifyIconInteracted;
                _notify.Visible = true;
            }
            private static void SetTimer()
            {
                _timer = new System.Timers.Timer(2000); //Timer goes off every 2 seconds
                _timer.Elapsed += Timer_Elapsed;
                _timer.AutoReset = true;
                _timer.Enabled = true;
            }
            private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                Console.WriteLine("Timer fired");
            }
            private static void NotifyIconInteracted(object sender, EventArgs e)
            {
                Console.WriteLine("Icon clicked");
            }
        }
    }
