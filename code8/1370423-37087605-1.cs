        private async void NewMethod(string url)
        {
            var json = await FetchAsync(url);
            using (FileStream fs = new FileStream("cache1.txt", FileMode.Create))
            {
                json.Save(fs);
            }
            Debug.WriteLine(json);
        }
