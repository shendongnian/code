    // New code:
        static HttpClient client = new HttpClient();
        static void Main()
        {
            RunAsync().Wait();
        }
        static async Task RunAsync()
        {
            // New code:
            client.BaseAddress = new Uri( "https://us5.api.mailchimp.com/3.0/" );
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Basic", "<YOUR_API_KEY_HERE>" );
            try {
                HttpResponseMessage response = await client.GetAsync( "" );
                if ( response.IsSuccessStatusCode ) {
                    var results = await response.Content.ReadAsStringAsync();
                    Console.WriteLine( $"results  (HTTP Status = {results})" );
                }
                else {
                    Console.WriteLine( $"ERROR (HTTP Status = {response.StatusCode}" );
                }
            }
            catch ( Exception e ) {
                Console.WriteLine( e.Message );
            }
            Console.ReadLine();
        }
