     namespace minimizeApp
        {
       
        public partial class MainWindow : Window
        {
            List<pkscheme> pkschemes = new List<pkscheme>();
    
            UserControl1 pkcs_w = null;
            public MainWindow()
            {
                InitializeComponent();
    
                //1st row
                pkscheme pk = new pkscheme();
                pk.name = "pk";
                pk.author = "pkAuthor";
                pk.screenshot = "pkScreenshot";
                pk.download = "pkDownload";
    
                //2nd row
                pkscheme pk1 = new pkscheme();
                pk1.name = "pk1";
                pk1.author = "pkAuthor1";
                pk1.screenshot = "pkScreenshot1";
                pk1.download = "pkDownload1";
    
                pkschemes.Add(pk);
                pkschemes.Add(pk1);
    
                pkcs_w = new UserControl1();
                pkcs_w.Width = 800;
                pkcs_w.Height = 500;
                pkcs_w.pkcsTable.ItemsSource = pkschemes;
    
                grid1.Children.Add(pkcs_w);
            }
        }
    
        public class pkscheme
        {
            public string name { get; set; }
            public string author { get; set; }
            public string screenshot { get; set; }
            public string download { get; set; }
        }
    }
