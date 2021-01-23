    public class ConversionViewModel()
    {
        private static ConversionViewModel _this;
        public ConversionViewModel()
            {
                InitializeComponent();
                _this = this;
            }
    
            public static ConversionViewModel GetInstance()
            {
                return _this;
            }
    
          //Other prop and methods
    }
    
    private void myTreeView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                try
                {
    
                    Field selectedField = new Field();
    
                    selectedField = (Field)myTreeView.SelectedItem;
    
                   ConversionViewModel.GetInstance().AddConversionType(selectedField.Table, selectedField.Name);                       
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
