      var values = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("Tokenid", Convert.ToString(lgntoken))
                    };
               string url = ".../get_projects_list.php";
             
              
               var handler = new HttpClientHandler
               {
                   CookieContainer = MainPage.cookies,
                   UseDefaultCredentials = true,
                   UseCookies = true
                  
               };
               System.Diagnostics.Debug.WriteLine("Login Token: " + Convert.ToString(lgntoken) + "..");
             //  var httpClient = new HttpClient(handler);
               HttpClient htclient = new HttpClient(handler);
               htclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
               HttpResponseMessage response = await htclient.PostAsync(url, new FormUrlEncodedContent(values));
               response.EnsureSuccessStatusCode();
               var responseString = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine("Project List Data : " + responseString + 
    "  ++ Login Token: " + Convert.ToString(lgntoken) + "..");
    
    ...
    }
