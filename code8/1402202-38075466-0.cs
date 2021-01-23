    public partial class MainWindow : Window{
          public String myTextProperty {get; set;}
    
          public MainWindow(){
              InitializeComponent();
              myTextPropety = "It works!";
              this.DataContext = this;
          }
    }
