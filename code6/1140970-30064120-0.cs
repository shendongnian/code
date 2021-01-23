     namespace Banking_System
     {       
         public partial class MainWindow : Window
         {
            public MainWindow()
            {
                InitializeComponent();           
            }
            private void btnSwitchForm_Click(object sender, RoutedEventArgs e)
            {               
                Window2 newWindow = new Window2(strForm1Text);
                newWindow.DataContext = this;
                newWindow.ShowDialog();      
            }            
      }
   
     public partial class MainWindow2 : Window
     {
          public MainWindow2()
          {
             var window1 = this.DataContext;
          }
     }  
