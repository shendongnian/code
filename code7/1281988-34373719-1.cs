    public partial class ProductView : Window, IDialogService
    {
       
        public ProductView()
        {
            InitializeComponent();
            this.DataContext = new EditProductViewModel(this);
           
        }
        public void CloseDialog()
        {
            if (this != null)
                this.Visibility = Visibility.Collapsed;
        }
        public void ShowDialog(EditProductViewModel prodVM)
        {
            this.DataContext = prodVM;
            this.Show();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
        
    }
