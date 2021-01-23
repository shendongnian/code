    public class ViewModel : BaseObservableObject
    {
        public ObservableCollection<ColumnDescriptor> ColumnHeaders
        {
            get { return _columnHeaders; }
            set
            {
                if (_columnHeaders == value)
                    return;
                _columnHeaders = value;
                OnPropertyChanged(() => ColumnHeaders);
            }
        }
        public ObservableCollection<Person> Data
        {
            get { return _data; }
            set
            {
                if (_data == value)
                    return;
                _data = value;
                OnPropertyChanged(() => Data);
            }
        }
        //here I've changed the column object from string to ColumnDescriptor object,
        //to match the values defined in AttachedPropeties (GridViewColumns class)
        //please keep in mind that every colun is binded to data in model, thus if your model 
        //won't have property named Salary, but your ColumnHeaders collection will have the ColumnDescriptor 
        //with that DisplayMember you will have binding expression exception in output window.
        //So you have define ColumnHeaders collection with certain number of ColumnDescriptors (as you want to display by model).
        private ObservableCollection<ColumnDescriptor> _columnHeaders;
        //since the Data is binded to the listview that give its ItemsSource to the GridView,
        //we don't have to have an ObservableCollection of ObservableCollections of objects, we can provide the actual values and 
        //they will be distrebuted to presented columns
        private ObservableCollection<Person> _data;
        public ViewModel()
        {
            ColumnHeaders = new ObservableCollection<ColumnDescriptor>
            {
                new ColumnDescriptor {HeaderText = "Last name", DisplayMember = "LastName", ColumnTemplateTemplateKey = typeof(String)},
                new ColumnDescriptor {HeaderText = "First name", DisplayMember = "FirstName", ColumnTemplateTemplateKey = typeof(String)},
                new ColumnDescriptor {HeaderText = "Salary", DisplayMember = "Salary", ColumnTemplateTemplateKey = typeof(String)},
                new ColumnDescriptor {HeaderText = "Date Of Birth", DisplayMember = "DateOfBirth", ColumnTemplateTemplateKey = typeof(DateTime)},
                new ColumnDescriptor {HeaderText = "Gift Was Delivered", DisplayMember = "GiftWasDelivered", ColumnTemplateTemplateKey = typeof(Boolean)},
            };
            Data = new ObservableCollection<Person>();
            for (int i = 0; i < 5; i++)
            {
                Data = new ObservableCollection<Person>
                {
                    new Person {FirstName = "John", LastName = "A.", DateOfBirth=new DateTime(1965, 12, 1), GiftWasDelivered = false},
                    new Person {FirstName = "Ron", LastName = "B.", DateOfBirth=new DateTime(1995, 6, 8), GiftWasDelivered = false}
                };
            }
        }
    }
    /// <summary>
    /// defines the column data (column heder text and column content)
    /// </summary>
    public class ColumnDescriptor
    {
        /// <summary>
        /// defines the actual text that will be shown in the grid view column header
        /// </summary>
        public string HeaderText { get; set; }
        /// <summary>
        /// defines the name of the property in view model that will be presented by this column
        /// </summary>
        public string DisplayMember { get; set; }
        /// <summary>
        /// defines the key of thew template
        /// </summary>
        public object ColumnTemplateTemplateKey { get; set; }
    }
    public class Person:BaseObservableObject
    {
        private string _name;
        private string _lastName;
        private DateTime _dateOfBirth;
        private bool _giftWasDelivered;
        public bool GiftWasDelivered
        {
            get { return _giftWasDelivered; }
            set
            {
                _giftWasDelivered = value;
                OnPropertyChanged();
            }
        }
        public string FirstName
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }
    }
