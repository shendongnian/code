    private static string JsonFile = "myFile.dat";    //your file name
    public static async Task<List<string>> LoadFromJsonAsync()
        {
            string JsonString = await DeserializeFileAsync(JsonFile);
            if (JsonString != null)
                return (List<string>)JsonConvert.DeserializeObject(JsonString, typeof(List<string>));
            return null;
        }
    private static async Task<string> DeserializeFileAsync(string fileName)
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
        }
