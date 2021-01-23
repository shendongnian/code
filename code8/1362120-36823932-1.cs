    class Base_ViewModel : BasePropertyChanged
    {
        
        public RelayCommand<buyer> ButtonClickCommand { get; set; }
        private ObservableCollection<buyer> _buyer;
        public ObservableCollection<buyer> buyer
        {
            get { return _buyer; }
            set { _buyer = value; }
        }
        public Base_ViewModel()
        {
            ButtonClickCommand = new RelayCommand<buyer>(OnButtonClickCommand);
            buyer = new ObservableCollection<ViewModels.buyer>();
            buyer.Add(new buyer() { buy_id = 1, bname = "John Doe", mobileno = "" });
        }
        private void OnButtonClickCommand(buyer obj)
        {
        }
    }
