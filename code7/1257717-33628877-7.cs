    public class YourViewModel:ViewModelBase
    {
        int _contentButtonDisplaySearch = 1;
        public string ChangeContentButtonDisplaySearch
        {
            get { return _contentButtonDisplaySearch; }
            set
            {
                //if(_contentButtonDisplaySearch!= value)//this condition is not appropriate 
                //cause we have just new `string` object and this newly created
                //`string` object will be always equal to the `value` of property
                _contentButtonDisplaySearch = value;
                OnPropertyChanged("ChangeContentButtonDisplaySearch");
            }
        }
        private ICommand _changeCountCommand;
        public ICommand ChangeCountCommand
        {
            get
            {
                if (_changeCountCommand == null)
                {
                    _changeCountCommand = new RelayCommand(
                    p => ChangeViewModel(),
                    p => true);
                }
                return _changeCountCommand;
            }
        }
        private void ChangeViewModel()
        {
            ChangeContentButtonDisplaySearch++;            
        }  
    }
