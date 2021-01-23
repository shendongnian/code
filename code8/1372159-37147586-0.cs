    private async Task GetSampleDataAsync()
            {
                if (this._groups.Count != 0)
                    return;
    
                Uri dataUri = new Uri("ms-appx:///DataModel/SampleData.json");
    
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
                string jsonText = await FileIO.ReadTextAsync(file);
                JsonObject jsonObject = JsonObject.Parse(jsonText);
                JsonArray jsonArray = jsonObject["Groups"].GetArray();
    
                foreach (JsonValue groupValue in jsonArray)
                {
                    JsonObject groupObject = groupValue.GetObject();
                    SampleDataGroup group = new SampleDataGroup(groupObject["UniqueId"].GetString(),
                                                                groupObject["Title"].GetString(),
                                                                groupObject["Subtitle"].GetString(),
                                                                groupObject["ImagePath"].GetString(),
                                                                groupObject["Description"].GetString());
    
                    foreach (JsonValue itemValue in groupObject["Items"].GetArray())
                    {
                        JsonObject itemObject = itemValue.GetObject();
                        group.Items.Add(new SampleDataItem(itemObject["UniqueId"].GetString(),
                                                           itemObject["Title"].GetString(),
                                                           itemObject["Subtitle"].GetString(),
                                                           itemObject["ImagePath"].GetString(),
                                                           itemObject["Description"].GetString(),
                                                           itemObject["Content"].GetString()));
                    }
                    this.Groups.Add(group);
                }
            }
