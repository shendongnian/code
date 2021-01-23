                /* private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
             {
                 PhoneCallManager.ShowPhoneCallUI("0213132131", "my name");
             }*/
            public async Task<string> FetchAsync(string url)
            {
                string jsonString;
    
                using (var httpClient = new System.Net.Http.HttpClient())
                {
                    var stream = await httpClient.GetStreamAsync(url);
                    StreamReader reader = new StreamReader(stream);
                    jsonString = reader.ReadToEnd();
                }
                return jsonString;
            }
        } 
    } // <-- Add this one, right here
