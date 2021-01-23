    public partial class Page1 : ContentPage
    {
        private Person _person;
        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }
        public Page1()
        {
            BindingContext = this;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            Person = new Person() { Date = DateTime.Now };
            base.OnAppearing();
        }
    }
