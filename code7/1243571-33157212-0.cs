    private async Task LoadData()
        {
            DestinationCombo.Items.Clear();
            SourceCombo.Items.Clear();
            file = await ApplicationData.Current.LocalFolder.GetFileAsync("jsonText.txt");
            var jsonContent = await FileIO.ReadTextAsync(file);
            DataModel2.RootObject states = JsonConvert.DeserializeObject<DataModel2.RootObject>(jsonContent);
            foreach (var state in states.country.state)
            {
                foreach (var city in state.city)
                {
                    cities.Add(city);
                }
            }
            DestinationCombo.Items.AddRange(cities.ToArray<String>());
            SourceCombo.Items.AddRange(cities.ToArray<String>());
        }
