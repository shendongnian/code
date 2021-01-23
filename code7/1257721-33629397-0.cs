     public partial class MainWindow : IView
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            public void ShowIView()
            {
                this.Show();
            }
    
            public void ShowViewAsModal()
            {
    
                this.ShowDialog();
            }
    
            public void SetDataContext(object dataContext)
            {
                this.DataContext = dataContext;
               
            }
