        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            // Create the ViewModel to which 
            // the main window binds.
            string path = "Data/customers.xml";
            var viewModel = new MainWindowViewModel(path);
            // When the ViewModel asks to be closed, 
            // close the window.
            EventHandler handler = null;
            handler = delegate
            {
                viewModel.RequestClose -= handler;
                window.Close();
            };
            viewModel.RequestClose += handler;
            // Allow all controls in the window to 
            // bind to the ViewModel by setting the 
            // DataContext, which propagates down 
            // the element tree.
            window.DataContext = viewModel;
            // the following line is added
            viewModel.Commands.FirstOrDefault(q => q.DisplayName == Strings.MainWindowViewModel_Command_ViewAllCustomers).Command.Execute(null);
            window.Show();
        }
