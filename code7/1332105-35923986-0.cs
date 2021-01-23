    public bool IsBusy {
        get {
            return _isBusy;
        }
        set {
            _isBusy = value;
            RaisePropertyChanged();
            Application.Current.Dispatcher.Invoke(
                        DispatcherPriority.ApplicationIdle,
                        new Action(() => {
                            WaitOneSecondsCommand.RaiseCanExecuteChanged();
                            WaitTenSecondsCommand.RaiseCanExecuteChanged();
                            WaitThirtySecondsCommand.RaiseCanExecuteChanged();
                        }));        }
    }
