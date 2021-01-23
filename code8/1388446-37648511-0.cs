    public partial class MainWindow : Window
    {
        ObservableCollection<Dimension> dimensionList = new ObservableCollection<Dimension>();
    
        public MainWindow()
        {
            InitializeComponent();
            //----set binding source for listview----//
            listView.ItemsSource = dimensionList;
        }
    
        private void calculate_bttn_Click(object sender, RoutedEventArgs e)
        {
            Calculate();           
        }
    
        private void Calculate()
        {
            //----get height from textbox-------------------print height to console----//
            int height = Int32.Parse(height_TB.Text); Console.WriteLine("Height: " + height);
    
            //----get width from textbox--------------------print width to console----// 
            int width = Int32.Parse(width_TB.Text); Console.WriteLine("Widht: " + width);
    
            //----converting square inches into square feet----//
            int toSquareInches = height * width;
            int toSquareFeet = toSquareInches / 144;
    
            //----create new dimension----//
            Dimension dim = new Dimension();
    
            //----set dimension properties----////
            dim.height = height;
            dim.width = width;
            dim.sqrInches = toSquareInches;
            dim.sqrFeet = toSquareFeet;
    
            //----add new dimension to dimensionList----//
            dimensionList.Add(dim);        
    
            //----display final square footage----//
            total_label.Content = "Total: " + toSquareFeet.ToString() + " square feet";
        }
    }
