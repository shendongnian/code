    private void ConvertLargeFile()
    {
        using (var inputStream  = new FileStream("C:\\Users\\test\\Desktop\\my.zip", FileMode.Open, FileAccess.Read)) 
        {
            byte[] buffer = new byte[MultipleOfThree];
            int bytesRead = inputStream.Read(buffer, 0, buffer.Length);
            while(bytesRead > 0)
            {
                String base64String = Convert.ToBase64String(buffer, 0, bytesRead);
                File.AppendAllText("C:\\Users\\test\\Desktop\\Base64Zip", base64String); 
                bytesRead = inputStream.Read(buffer, 0, buffer.Length);           
            }
        }
    }
