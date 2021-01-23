    private List<int> my_list = new List<int>();
    public async Task GenericDataWrite()
    {
        // Get the local folder.
        StorageFolder data_folder = Windows.Storage.ApplicationData.Current.LocalFolder;
        // Create a new file named data_file.xml
        StorageFile file = await data_folder.CreateFileAsync(@"data_file.xml", CreationCollisionOption.ReplaceExisting);
        // Write the data
        using (Stream s = await file.OpenStreamForWriteAsync())
        {
            try
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<int>));
                serializer.Serialize(s, my_list);
                s.Close();
            }
            catch(Exception ex)
            {
                string error_message = ex.Message;
            }
        }
    }
    public async Task GenericDataRead()
    {
        // Get the local folder.
        StorageFolder data_folder = Windows.Storage.ApplicationData.Current.LocalFolder;
        if (data_folder != null)
        {
            StorageFile file = await data_folder.GetFileAsync(@"data_file.xml");
            // Get the file.
            System.IO.Stream file_stream = await file.OpenStreamForReadAsync();
            // Read the data.
            using (StreamReader streamReader = new StreamReader(file_stream))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<int>));
                my_list = (List<int>)serializer.Deserialize(streamReader);
                streamReader.Close();
            }
            file_stream.Close();            
       }
    }
