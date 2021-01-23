    using (StreamReader sr = new StreamReader(file))
    {
        String line;
        List<string> myEmailList = new List<string>();
    
        while ((line = sr.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            string email = parts[1];
            Debug.Write(email + "\n");//writes out email column
            myEmailList.Add(email);
        }
        foreach (var customer in myEmailList)
        {
            if (folder.path.Contains("first")){ 
                 //Do stuff with "Customer"
                 //call API and send TemplateA
            }    
            else if(folder.path.Contains("second"))
            {
                 //Do stuff with "Customer"
                 //call API and send TemplateB
            }
            else
            {
                 //Do stuff with "Customer"
                 //call API and send TempateC
            }
        }
    }
