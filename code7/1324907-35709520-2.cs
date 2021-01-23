     NameValueCollection kv = new NameValueCollection();// Choose your data structure. name value collection allows duplicates.
     using (StreamReader oReader = new StreamReader("your_file_path"))
     {
            while ((sLine = oReader.ReadLine()) != null)
            {
                 if(!sLine.Contains("[IntTimes]") && !sLine.Contains("[IntNotes]"))
                {
                     string[] sLineItems = sLine.Split('\t');// Assuming the file is tab delimited.
                     kv.Add(sLineItems[0],sLineItems[3]);
                     Console.WriteLine(sLineItems[0],sLineItems[3]);
                } 
            }
     }
     foreach(string key in kv.AllKeys)
            Console.WriteLine(key,kv[key]);
