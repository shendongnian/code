    using System.Diagnostics;
    using System.IO;
    using System.IO.Pipes;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace SampleApp.B
    {
        public partial class MainWindow : Window
        {
            private NamedPipeServerStream pipeServer;
            public string Text { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                this.Loaded += MainWindow_Loaded;
                this.Closing += MainWindow_Closing;
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                Process.Start(@"C:\Users\bk\Desktop\SampleApp V2\SampleApp.A\bin\Debug\SampleApp.A.exe");
                pipeServer = new NamedPipeServerStream("1234", PipeDirection.In);
                pipeServer.WaitForConnection();
            }
    
            private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                if (pipeServer.IsConnected)
                {
                    pipeServer.Disconnect();
                }
                pipeServer.Close();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (pipeServer.IsConnected)
                {
                    using (var sr = new StreamReader(pipeServer))
                    {
                        Text = sr.ReadLine();
                    }
                }
    
                label.Content = Text;
            }
        }
    }
