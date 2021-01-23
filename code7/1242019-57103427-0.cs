        static async Task InfluxPostAsync()
        {
            var influxPostData = "influxdbname,tag1=tag1value value=1000";
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("http://influxserver:8086");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "aW5mblahblahblahblahblahNXMyNQ==");
                var content = new System.Net.Http.StringContent(influxPostData, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/write?db=influxdbname&precision=s", content);
                string resultContent = await result.Content.ReadAsStringAsync();
            }
        }
        static void Main(string[] args)
        {
            Task.Run(() => InfluxPostAsync());
        }
