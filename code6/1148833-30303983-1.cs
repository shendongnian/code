    public RelayCommand PageUnLoadedCommand { get; private set; }
    ...
     PageUnLoadedCommand = new RelayCommand(() => OnPageUnLoadedCommand());
...
        private void OnPageUnLoadedCommand()
        {
            //Unsubscribe and dispose here
        }
