     FileInfo Finfo;
     public bool StartLog(string path)
     {
          Finfo = new FileInfo(path);
          if (Finfo.Exists)
          {
              Finfo.Delete();
              FileWriter = Finfo.AppendText();                   
          }
          else
          {              
              FileStream fs = Finfo.Create();
              fs.Close();
              FileWriter = Finfo.AppendText();
          }
     }
