            var webClient = new System.Net.WebClient();
            try
            {
                var str = webClient.DownloadString("http://search.twitter.com/search.json?q=xamarin&rpp=10&include_entities=false&result_type=mixed");
               
                System.Diagnostics.Debug.WriteLine(str);
            }
            catch (System.Net.WebException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            } 
