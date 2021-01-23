     var items = from item in loadedData.Descendants("GirlsTimes")
                                    where item.Element("Angie").Name == "Angie"
                                    select item;
    
                        foreach (XElement itemElement in items)
                        {
                            itemElement.SetElementValue("Angie", TBAngie.Text);
                        }
    
                        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                        StorageFile textFile = await localFolder.CreateFileAsync("GirlsTimes.xml", CreationCollisionOption.ReplaceExisting);
                        using (IRandomAccessStream textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite))
                        {
                            using (DataWriter textWriter = new DataWriter(textStream))
                            {
                                textWriter.WriteString(loadedData.ToString());
                                await textWriter.StoreAsync();
                            }
                        }
