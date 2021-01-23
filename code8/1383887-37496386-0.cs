    public async void ProcessRead()
    {
     string filePath = @"temp2.txt";
     if (File.Exists(filePath) == false)
     {
         Debug.WriteLine("file not found: " + filePath);
     }
     else
     {
         try
         {
             string text = await ReadTextAsync(filePath);
             Debug.WriteLine(text);
         }
         catch (Exception ex)
         {
             Debug.WriteLine(ex.Message);
         }
     }
    }
