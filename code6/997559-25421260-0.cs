    string url = @"E:Data.dat";
    using (Stream stream = File.Open(url, FileMode.Open, FileAccess.Read,     FileShare.ReadWrite))
    {
        using (StreamReader sr = new StreamReader(stream))
        {
             string str = sr.ReadToEnd();
             var characterIndex = str.IndexOf('~');
             if (characterIndex >= 0)
             {
                var result = str.SubString(characterIndex, str.Length - characterIndex);
                // Work from here
             }
        }
    }
