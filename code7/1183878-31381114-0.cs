    static readonly Mutex singleton = new Mutex(true, "AppName");
        static void Main()
                {
                    if (!singleton.WaitOne(TimeSpan.Zero, true))
                    {
                       MessageBox.Show("Another instance is running.");
                       return;
                    }
                }
