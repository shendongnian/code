    public class ViewModel1 : ViewModelBase
    {
        private RelayCommand _refreshCommand;
        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand = new RelayCommand(() =>
                {
                    // You button command code
                    // -------------------
                    // Send a message
                    Messenger.Default.Send<Vm1toVm2Message>( new Vm1toVm2Message { Message = "Update from VM1" });
                }));
            }
        }
    }
