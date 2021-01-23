        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await makeEventwebRequest(number.Text,date.Text);
            NavigationService.Navigate(new Uri("/page2.xaml", UriKind.Relative));
        }
        public async void makeEventwebRequest(string numb, string date)
        {
            string requesturi = string.Format(baseUri, numb, date);
            var request = (HttpWebRequest)WebRequest.Create(requesturi );
            var result = await GetHttpResponse(request);
            App.mydirectories = JsonConvert.DeserializeObject<directoriescs>(result);
        }
        // Method helper to Http async request
        public static async Task<String> GetHttpResponse(HttpWebRequest request)
        {
            String received = null;
            try
            {
                using (var response = (HttpWebResponse)(await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null)))
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(responseStream))
                        {
                            received = await sr.ReadToEndAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return received;
        }
