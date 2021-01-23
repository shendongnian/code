            private bool newPage = true;
            public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            await Serializer();
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (newPage == true) 
            {
                await Deserializer();
                newPage = false;
            }
        }
    public async Task Serializer()
        {
            var folder = ApplicationData.Current.RoamingFolder;
            var file = await folder.CreateFileAsync("collection.json", CreationCollisionOption.ReplaceExisting);
            using (var stream = await file.OpenStreamForWriteAsync())
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                string json = JsonConvert.SerializeObject(MemoryItems);
                await writer.WriteAsync(json);
            }
        }
        public async Task Deserializer()
        {
            try
            {
                var folder = ApplicationData.Current.RoamingFolder;
                var file = await folder.GetFileAsync("collection.json");
                using (var stream = await file.OpenStreamForReadAsync())
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var json = await reader.ReadToEndAsync();
                    ObservableCollection<MemoryItem> MemoryItems = JsonConvert.DeserializeObject<ObservableCollection<MemoryItem>>(json);
                    if(MemoryItems != null)
                    {
                        foreach (var item in MemoryItems)
                        {
                            var sb = new StringBuilder();
                            sb.Append(item.Memory);
                            var fileString = sb.ToString();
                            var memoryItem = new MemoryItem
                            {
                                Memory = fileString
                            };
                            this.MemoryItems.Add(memoryItem);
                        }
                    }
                    else
                    {
                        Memory();
                    } 
                }
            }
            catch (Exception)
            {
                // Handle Exception.
            }
        }
