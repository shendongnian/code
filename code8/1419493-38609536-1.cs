    public static ViewModel Instance {get; set;}
    public class MainWindow : Window
    {
       InitializeComponent();
       if(ViewModel.Instance == null)
       {
           ViewModel.Instance = new ViewModel();           
       }
       this.DataContext = ViewModel.Instance;
    }
