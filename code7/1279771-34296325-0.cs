                StorageFile file = await createFile("filename.json");
                using (JsonTextWriter jsonwriter =new JsonTextWriter(new StreamWriter(await file.OpenStreamForWriteAsync())))
                {
                    var serializer = new JsonSerializer();
                    serializer.TypeNameHandling = TypeNameHandling.All;
                    serializer.Serialize(jsonwriter, DataObject);
                }
