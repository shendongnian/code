    public partial class MainWindow : Window
    {
        BackgroundWorker bw;
        public MainWindow()
        {
            InitializeComponent();
            bw = new BackgroundWorker();
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            bw.DoWork += (o, a) =>
            {
                try
                {
                    string str = "";
                    textBox.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => 
                    { 
                        str = textBox.Text;
                        MessageBox.Show(str);     
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //e.Result = LoadXmlDoc();
            };            
            bw.RunWorkerAsync();
        }
