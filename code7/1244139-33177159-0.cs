    static bool IsValidFileType(string filename)
    {
        bool results = false;
        string ext = Path.GetExtension(filename);
        List<string> fileTypes = new List<string>();
        fileTypes.Add("exe");
        fileTypes.Add("mse");
        //etc
        for (int i = 0; i < fileTypes.Count; i++)
        {
            if (ext == fileTypes[i])
            {
                results = true;
                break;
                //or just return true;
            }
        }
        return results;
    }
