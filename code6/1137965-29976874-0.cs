    protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IMailSender, Model.Concrete.GmailSender>();
            var mainWindow = container.Resolve<MainWindow>();            
            Application.Current.MainWindow = mainWindow;
            Application.Current.MainWindow.Show();
        }
