        public async Task DoJobAsync()
        {
            XDocument xmlDoc = XDocument.Load("favourite//fav.xml");
            xmlDoc.Root.Add(new XElement("drink",
                        new XAttribute("drinkImage", "ck.png"),
                        new XAttribute("drinkTitle", "PEPSI"),
                        new XAttribute("drinkDescription", "NONE")
                    ));
            using (var stream = await (await ApplicationData.Current.LocalFolder.CreateFileAsync("fav.xml")).OpenAsync(FileAccessMode.ReadWrite))
            {
                xmlDoc.Save(stream.AsStreamForWrite());
            }
        }
