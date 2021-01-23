        string content = string.Empty; 
        while(!sr.EndOfStream)
        {
          content = sr.ReadToEnd();       
        }      
        fs.Close();
        return content;
