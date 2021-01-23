        public MainWindow()
        {
            InitializeComponent();
            Dispatcher.InvokeAsync(
                BindingOperations.GetMultiBindingExpression(Ellipse, ClipProperty).UpdateTarget,
                DispatcherPriority.Background);
        }
