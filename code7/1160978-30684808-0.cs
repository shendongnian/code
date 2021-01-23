         public partial class MainWindow : Window
    {
        String stringfound;
        public MainWindow()
        {
            InitializeComponent();
        }
        void clickhandler(object sender, RoutedEventArgs e)
        {
            String line;
            try
            {
                StreamReader file = new StreamReader("d:\\test.txt");
               
                    while((line = file.ReadLine()) != null )
                    {
                        if (line.Contains("BLOCK2")) 
                        {
                            stringfound=line;
                            break;
                            
                           
                        }
                       
                    }
                
                if(stringfound=="BLOCK2") // checking if BLOCK2 exists or not
                {
                    while (line != "ENDOFBLOCK" && line != null)
                    {
                        line = file.ReadLine();
                    }
                }
                else                 // BLOCK2 not found
                {
                   // do something else  
                }
              
               
              
            }
            catch(Exception)
            {
                MessageBox.Show("unknown exception occurred");
            }
        }
    }
}
