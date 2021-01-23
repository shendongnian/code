    private void ReadFile(string filePath, string customerPhone, string customerName)
    {
        string line = string.Empty;
        var fileSR = new StreamReader(filePath);
        bool number = true;
     
        List<string> customerPhone = new List<string>();
        List<string> customerName = new List<string>();
        while((line = fileSR.ReadLine()) != null)
        {
            if (number)
            {
                customerPhone.Add(line);
                number = false;
            }
            else
            {
                customerName.Add(line);
                number = true;
            }
       }
    
       fileSR.Close();
    }
