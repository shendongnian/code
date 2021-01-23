    public partial class MainWindow : Window
    {
    
        //Your data
        private string date = "2016-04-04";
        private string time = "20:20";
        private string description = "poop";
    
        //Declare a list
        public List<object> myList { get; set; }
    
    
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
    
            //Instantiate your list
            myList = new List<object>();
    
            //Make a new object
            var listObject = new
            {
                newDate = date,
                newTime = time,
                newDescription = description
            };
    
            //Add that object to your list
            myList.Add(listObject);
        }
    }
