        public async void Remote_Push(BlockList Blocks)
        {
            // Pushes pending records to the remote server
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(Context.ServerUrl);
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = JsonCompress(Blocks);
                var jsonGip = new JsonGzip() {gzip = content};
                return await Client.PostAsync("SyncPush/", jsonGip);
            }
        }
