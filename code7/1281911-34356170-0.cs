    public string GetFileFromManifest(string path){
        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
        {
            stream.Position = 0;
    
            using (var streamReader = new StreamReader(stream))
            {
                return streamReader.ReadToEnd();
            }
        }
    
    }
