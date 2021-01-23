                file = await ApplicationData.Current.LocalFolder.GetFileAsync("EortologioMovingEntries.xml");
            try
            {
                using (IRandomAccessStream stream =
                await file.OpenAsync(FileAccessMode.Read))
                using (Stream inputStream = stream.AsStreamForRead())
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(Anniversaries), "Anniversaries", "http://schemas.datacontract.org/2004/07/Eortologio.Model");
                    tempAnniversaries = serializer.ReadObject(inputStream) as Anniversaries;
                }
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                tempAnniversaries.Entries.Add(new AnniversaryEntry("Ena", DateTime.Now, "skata", PriorityEnum.High));                
            }
