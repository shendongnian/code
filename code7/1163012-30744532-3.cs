    using System.IO;
    /// Read Text Document specified by full path
    private string ReadTextDocument(string TextFilePath)
    {
        string _text = String.Empty;
        try
        {
            // open file if exists
            if (File.Exists(TextFilePath))
            {
                using (StreamReader reader = new StreamReader(TextFilePath))
                {
                    _text = reader.ReadToEnd();
                    reader.Close();
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
            return _text;
        }
        catch { throw; }
    }
