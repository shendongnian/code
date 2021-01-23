    [STAThread]
        static void Main()
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);
                using (new SingleGlobalInstance(TIMEOUT_START))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    _mainProgram = new frmMainProgram();
                    ApplicationContext appCtx = new ApplicationContext(_mainProgram);
                    Application.Run(appCtx);
                }
            }
            catch (Exception unhandled)
            {
                Program.UnhandledExceptionHandler(null, (new UnhandledExceptionEventArgs(unhandled, true)));
            }
        }
