        public static async Task SomeTaskName()
        {
            //doing some sync code > will execute
            //doing the async part > will execute
            using (HttpClient httpClient = new HttpClient())
            {
                //HttpResponseMessage result = await httpClient.GetAsync("https://google.com"); //-- skip the await
                Task<HttpResponseMessage> result = httpClient.GetAsync("https://google.com");
                await System.Threading.Tasks.Task.WhenAll(result).ContinueWith(y => {
                    string resultAsString = result.Result.Content.ReadAsStringAsync().Result;
                    //put the reset of your sync code here to execute after "httpClient.GetAsync("https://google.com");" is completed
                });
                //any code here wont execute
            }
            //any code here wont execute
        }
