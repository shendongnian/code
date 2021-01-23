     static void Main()
     {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         string[] args = Environment.GetCommandLineArgs();
         // Creates the Splash
         splash = new FrmSplash();
         //Opens the Splash in a new Thread, this way any gifs, progress bars, lablels changes will work because the main thread isnt blocked
         var t = Task.Factory.StartNew(() =>
         {
             splash.ShowDialog();
         });
         // Some slow initialization code.
         // ...
         //Fecha a splash screen
         CloseSplash();
         Application.Run(args);
     }
     static void CloseSplash()
     {
         splash.Invoke(new MethodInvoker(() =>
         {
             splash.Close(); // Closes the splash that is running in the other thread
         }));
     }
