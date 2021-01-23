    public async static Task<Feed> ReadSetting<type>(string Key)
            {
                var rr = new Feed();
    
                try
                {
                    var ms = new MemoryStream();
                    DataContractSerializer serializer = new DataContractSerializer(typeof(type));
    
                    StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(Key);
                    using (IInputStream inStream = await file.OpenSequentialReadAsync())
                    {
                        rr.ArticlesList = (type)serializer.ReadObject(inStream.AsStreamForRead());
                    }
                }
                catch (FileNotFoundException)
                {
                    
                }
                return rr;
            }
