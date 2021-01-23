     private async void ContinuousWebRequest()
        {
            while (_keepPolling)
            {
                timeLabel.Text = "call: "+counter+" "+ await RequestTimeAsync()+Environment.NewLine;
                // Update the UI (because of async/await magic, this is still in the UI thread!)
                if (_keepPolling)
                {
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            }
        }
        static async Task<string> RequestTimeAsync()
        {
            using (var client = new HttpClient())
            {
                var jsonString = await client.GetStringAsync("http://date.jsontest.com/");
                var jsonObject = JObject.Parse(jsonString);
                TimePage.counter++;
                return jsonObject["time"].Value<string>();
            }
            
        }
