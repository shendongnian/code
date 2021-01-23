        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = await CheckProxies();
            label.Content = result.ToString();
        }
        async Task<int> CheckProxies()
        {
            //I don't actually HAVE a list of proxies, so I make up some data
            for (int i = 0; i < 1000; i++)
                values[Guid.NewGuid().ToString()] = null;
            progress.Maximum = 1000;
            await Task.Factory.StartNew(() => Parallel.ForEach(values, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, this.PeformOperation));
            //note that with maxDegreeOfParallelism set to a high value (like 1000)
            //then I'll get a TON of failed requests simply because I'm overloading the network
            //either that or google thinks I'm DDOSing them... >_<
            return values.Where(v => v.Value == true).Count();
        }
        void PeformOperation(KeyValuePair<string, bool?> kvp)
        {
            try
            {
                WebRequest request = WebRequest.Create("http://google.co.nz/");
                request.Timeout = 100;
                //I'm not actually setting up the proxy from kvp,
                //because it's populated with bogus data
                request.GetResponse();
                values[kvp.Key] = true;
            }
            catch (WebException)
            {
                values[kvp.Key] = false;
            }
        }
