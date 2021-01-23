    using (ManualResetEvent mre = new ManualResetEvent(false))
    {
        Thread thread = new Thread(new ThreadStart(
            delegate ()
            { 
                SplashScreenHelper.SplashScreen = new Splash()
                // this works. the splash screen opens
                SplashScreenHelper.Show();
                mre.Set(); // signal that we are done setting up the splash screen
                System.Windows.Threading.Dispatcher.Run();
            }
        ));
        thread.SetApartmentState(ApartmentState.STA);
        thread.IsBackground = true;
        thread.Start();
        mre.WaitOne(); // wait until the signal is received
    }
    check(); // now we can safely call check()
