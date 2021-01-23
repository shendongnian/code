        public MyView()
        {
            InitializeComponent();
            this.Closed += ((sender, arguments) =>
            {
                var viewModel = ((MyViewModel)this.DataContext);
                viewModel.Dispose();
                ViewModelLocator.UnregisterSourceCodeViewer(viewModel.ID);
                this.DataContext = null;
            });
        }
