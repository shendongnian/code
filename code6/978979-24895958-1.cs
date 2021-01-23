           public static CookieContainer cookies = new CookieContainer();
     private async void btnLogin_Click(object sender, RoutedEventArgs e)
            {
    ...
    var values = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("Email", txtEmail.Text),
                        new KeyValuePair<string, string>("Password", txtPassword.Password)
                    };
            string url = ".../login.php";
          
            
          
            var handler = new HttpClientHandler
            {
                CookieContainer = cookies,
                UseCookies = true,
                UseDefaultCredentials = false
            };
          
           
            HttpClient htclient = new HttpClient(handler);
            
            htclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            HttpResponseMessage response = await htclient.PostAsync(url, new FormUrlEncodedContent(values));
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
