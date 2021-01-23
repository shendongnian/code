    [HttpPost]
    public string GetCalculatorResults()
    {
        byte[] imgArr = GetImageFromDataBase();
        
        // Here we are converting the byte array to Base64String
        return Convert.ToBase64String(imgArr)
    }
