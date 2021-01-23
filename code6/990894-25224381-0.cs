    public partial class Shell : Window
    {
        #region Constructor(s)
        public Shell()
        {
            InitializeComponent();
            StateManager.IsBusyChange += new StateManager.IsBusyHandler(InitiateIsBusy);
        }
        #endregion Constructor(s)
        #region Event Actions
        public void InitiateIsBusy(object sender, BusyActionEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, ea) =>
            {
                e.IsBusyAction.Invoke();
                //Dispatcher.Invoke((Action)(() => e.IsBusyAction()));
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
                this.ShellBusyIndicator.IsBusy = false;
            };
            this.ShellBusyIndicator.IsBusy = true;
            worker.RunWorkerAsync();
        }
        #endregion Event Actions
    }
