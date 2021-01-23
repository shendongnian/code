    using (StreamReader sr = new StreamReader(file))
    {
        String line;
   
        while ((line = sr.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            string email = parts[1];
            Debug.Write(email + "\n");//writes out email column
            if (folder.path.Contains("first")){
                 //Do stuff with "email" 
                 //call API and send TemplateA 
            }    
            else if(folder.path.Contains("second"))
            {
                 //Do stuff with "email"
                 //call API and send TemplateB
            }
            else
            {
                 //Do stuff with "email"
                //call API and send TempateC
            }
        }
    }
