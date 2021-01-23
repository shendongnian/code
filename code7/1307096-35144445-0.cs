    public static async void Req()
    {
        using (var client = new HttpClient())
        {
            var values = new Dictionary<string, string>
            {
                 { "type1", "val1" },
                 { "type2", "val2" },
                 { "type3", "val3"}
            };
                var content = new FormUrlEncodedContent(values);
                var r1 = await client.PostAsync(URL, content);
                var responseString = await r1.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
                Console.ReadLine();
            }
        }
    }
