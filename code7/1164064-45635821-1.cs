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
         
          while (!splash.Created) // wait the splash screen form load process
              System.Threading.Thread.Sleep(300);
                    
         UpdateSplashMessage("Loading the program... Please wait");         
         // Some slow initialization code.
         // ...
         //Close splash screen
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
     static void UpdateSplashMessage(string msg)
     {
         splash.Invoke(new MethodInvoker(() =>
         {
             splash.AtualizarMensagem(msg);
         }));
     }
