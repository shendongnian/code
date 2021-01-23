            private static void Button_Click2(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://terasol.in/");
                var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("id", id)
            });
                var result = client.PostAsync("/hoo/test.php", content).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(resultContent);
            }
        }
