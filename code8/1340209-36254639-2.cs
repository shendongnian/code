    class MainWindowViewModel
        {
            public ICommand cmdExecuteSubmit { get; set; }
            public MainWindowViewModel()
            {
                cmdExecuteSubmit = new RelayCommand(doSubmitStuff);
            }
            public void doSubmitStuff(object sender)
            {
                //Do your action here
            }
       }
