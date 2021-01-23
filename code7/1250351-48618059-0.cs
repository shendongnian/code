    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace ApiTest
    {
        public class Description
        {
            public int id { get; set; }
            public int userId { get; set; }
            public string title { get; set; }
            public string body { get; set; }
        }
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private async void api_btn_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                        //HttpsPostRequest(URL);
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
    
                        Description desc = null;
                        var response = await client.GetAsync("posts/1").ConfigureAwait(false);
                        if (response.IsSuccessStatusCode)
                        {
                            desc = await response.Content.ReadAsAsync<Description>();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception caught.", ex);
                    //throw;
                }
            }
        }
    }
