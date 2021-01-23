            public async Task<bool> WriteFileAsync<T>(string key,T value)
                    {
                        var file =await ApplicationData.Current.LocalFolder.CreateFileAsync(key, CreationCollisionOption.ReplaceExisting);
                        //serialize
                        using(MemoryStream ms = new MemoryStream())
                        {
                            try
                            {
                                var serailizer = new DataContractSerializer(value.GetType());
                                serailizer.WriteObject(ms, value);
                                ms.Position = 0;
                                StreamReader reader = new StreamReader(ms);
                                var content = reader.ReadToEnd();
                                await FileIO.WriteTextAsync(file, content);
                                return true;
                            }
                            catch (Exception e)
                            {
                                return false;
                            }
                        }
                    }
                    public async Task<T> ReadFileAsync<T>(string key)
                    {
                        var file = await ApplicationData.Current.LocalFolder.GetFileAsync(key);
                        if(file==null)
                            return default(T);
                        var textContent = await FileIO.ReadTextAsync(file);
                        //Deserialize
         using (StringReader reader = new StringReader(textContent))
                    {
                        using (XmlReader xmlReader = XmlReader.Create(reader))
                        {
                            var serializer = new DataContractSerializer(typeof(T));
                            T theObject = (T)serializer.ReadObject(xmlReader);
                            return theObject;
                        }
                    }
                     //   using (MemoryStream ms = new //MemoryStream(Encoding.Unicode.GetBytes(textContent)))
                        //{
                          //  try
                          //  {
                               // var serailizer = new DataContractSerializer(typeof(T));
            
                               // return (T)serailizer.ReadObject(ms);
                            //}
                           // catch (Exception e)
                            //{
                                //return default(T);
                           // }
                       //
    
     }
                
                }
