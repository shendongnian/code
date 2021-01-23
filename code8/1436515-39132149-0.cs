        public async void LoadItemsAsync()
        {
            for (int i = 0; i < 10; i++)
                listBox1.Items.Add(await GetItem());
        }
        public Task<string> GetItem()
        {
            return Task<string>.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                return "Item";
            });
        }
