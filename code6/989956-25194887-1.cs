    string sPath = System.IO.Path.Combine(str_LogsDirectory, DateTime.Now.ToString("MMMM dd, yyyy") + ".txt");
    
    using(System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath))
    {
       foreach(var item in list_log.Items)
       { 
           SaveFile.WriteLine(item.ToString());
       }
    }
