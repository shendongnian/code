    class Base_ViewModel : BasePropertyChanged
    {
        
        public RelayCommand<ObservableCollection<buyer>> ButtonClickCommand { get; set; }
        private ObservableCollection<buyer> _buyer;
        public ObservableCollection<buyer> buyer
        {
            get { return _buyer; }
            set { _buyer = value; }
        }
        public Base_ViewModel()
        {
            ButtonClickCommand = new RelayCommand<ObservableCollection<buyer>>(OnButtonClickCommand);
            buyer = new ObservableCollection<ViewModels.buyer>();
            buyer.Add(new buyer() { buy_id = 1, bname = "John Doe", mobileno = "" });
            buyer.Add(new buyer() { buy_id = 1, bname = "Jane Doe", mobileno = "" });
            buyer.Add(new buyer() { buy_id = 1, bname = "Fred Doe", mobileno = "" });
            buyer.Add(new buyer() { buy_id = 1, bname = "Sam Doe", mobileno = "" });
        }
        private void OnButtonClickCommand(ObservableCollection<buyer> obj)
        {  // put a break-point here and obj will be the List of Buyer that you can then step though
        }
    }
