    using System.IO;
    using System.IO.Pipes;
    using System.Windows;
    
    namespace SampleApp.A
    {
        public partial class MainWindow : Window
        {
            private NamedPipeClientStream pipeClient;
            public string Text { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                this.Loaded += MainWindow_Loaded;
                this.Closing += MainWindow_Closing;
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                pipeClient = new NamedPipeClientStream(".", "1234", PipeDirection.Out);
                pipeClient.Connect();
            }
    
            private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                pipeClient?.Close();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Text = textBox.Text;
    
                using (var sw = new StreamWriter(pipeClient))
                {
                    sw.WriteLine(Text);
                    sw.Flush();
                }
            }
        }
    }
