    List<Dummy> lst = new List<Dummy>();
            for (var i = 0; i < 100000; i++)
            {
                lst.Add(new Dummy()
                        {
                            X =  i,
                            Y =  i * 2
                        });
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<Dummy>));
            // estimate your memory consumption ... it would be around 4 bytes reference + 4 bytes object type pointer + 8 bytes those ints + let's say another 4 bytes other hidden CLR metadatas. a total of 20 bytes per instance + 4 bytes reference to our object (in the list array) => around 24 bytes per instance. Round up to a let's say 50 bytes per instance. Multiply it by 100.000 = 5.000.000
            MemoryStream memStream = new MemoryStream(5000000);
            serializer.Serialize(memStream, lst);
            memStream.Position = 0;
            string tempDatafileName = null;
            var dataWasWritten = false;
            try
            {
                var fileName = Guid.NewGuid().ToString() + ".tempd";
                var specialFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                using (var fs = new FileStream(tempDatafileName, FileMode.Create, FileAccess.ReadWrite))
                    memStream.WriteTo(fs);
                dataWasWritten = true;
                memStream.Dispose();
                memStream = null;
                lst.Clear();
                lst = null;
                // force a full second generational GC
                GC.Collect(2);
                // reading the content in string
                string myXml = File.ReadAllText(tempDatafileName);
            }
            finally
            {
                if (dataWasWritten && string.IsNullOrWhiteSpace(tempDatafileName) == false)
                {
                    if (File.Exists(tempDatafileName))
                    {
                        try
                        {
                            File.Delete(tempDatafileName);
                        }
                        catch
                        {
                            
                        }
                    }
                }
            }
