        FileStream obj = new FileStream();
            using(StreamReader csvr = new StreamReader(obj))
    {
            string a = obj.ReadToEnd();
            a = a.Replace("\"","");
            a = a.Replace("\r\"","");
            obj.Dispose();
    }
            
            using(StreamWriter Wr = new StreamWriter(TempPath))
            {
              Wr.Write(a);
        
        }
        
        using(StreamReader Sr = new StreamReader(Tempath))
        {
        Sr.ReadLine();
        }
