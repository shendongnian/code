    public class SecondViewModel
        {
                
            protected readonly IEventAggregator _eventAggregator;
            public SecondViewModel(IEventAggregator eventAggregator)
            {
                this._eventAggregator = eventAggregator;
                
            }
    
         
    
            private void Go()
            {
                _eventAggregator.GetEvent<GoToThird>().Publish();
            }
           
           
            private ICommand goToThirdCommand;
    
            public ICommand GoToThirdCommand
            {
                get
                {
                    return goToThirdCommand ?? (goToThirdCommand = new RelayCommand(p => this.Go(), p => this.CanGo()));
                }
            }
    
            private bool CanGo()
            {
                return true;
            }
    }
