    public partial class MainPage : PhoneApplicationPage
    {
        List<ListQuantityClass> QuantitySource = new List<ListQuantityClass>();
        // Constructor
        public MainPage()
        {
            InitializeComponent();
         
            for (int i = 1; i <= 20; i++)
            {
                QuantitySource.Add(new ListQuantityClass() { Quantity = i });
            }
            my_listpicker.ItemsSource = QuantitySource;
            // setting default value to 3
            my_listpicker.SelectedItem = QuantitySource[2];
        }
    }
