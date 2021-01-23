    Public void SaveBinaryAsDocument(string filePath, string base64String)
        {
            Byte[] bytes = Convert.FromBase64String(base64String);
            File.WriteAllBytes(filePath, bytes);
        }
    
