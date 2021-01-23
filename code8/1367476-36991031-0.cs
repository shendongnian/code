    private static clientFileName = "yourfile.dat";
    public static async Task<List<ClientData>> LoadClientDataFromJsonAsync()
        {
            string clientJsonString = await DeserializeClientDataAsync(clientFileName);
            if (clientJsonString != null)
                return (List<ClientData>)JsonConvert.DeserializeObject(clientJsonString, typeof(List<ClientData>));
            return null;
        }
    private static async Task<ClientData> DeserializeClientDataAsync(string fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        
