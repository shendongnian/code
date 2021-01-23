      using System;
      using System.Net;
      using System.Windows;
     namespace RCC_1v2
     {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void GetType(object sender, RoutedEventArgs e)
        {
            WebClient wc = new WebClient();
            wc.Credentials = new NetworkCredential("xxx", "xxx");
            wc.DownloadStringAsync(new Uri("http://eremote-cam1.eu.ngrok.io/axis-cgi/param.cgi?action=list&group=root.Brand.ProdFullName"));
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
        }
        private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(() => {
                String run_text = e.Result.ToString();
                Run1.Text = run_text.Substring(24, 13);
                
            }));
        }
    }
    }
