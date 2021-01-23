    public void AddLog (string message, string fn_name)
        {
            string path = @"E:\" + fn_name +".txt";
            if (!File.Exists(path))
            {
                File.Create(path);
                
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine("" + message +"");
                tw.Close();
                File.Delete(path);
            }
            else if (File.Exists(path))
            {
                TextWriter tw = new StreamWriter(path,true);
                tw.WriteLine("" + message + "");
                tw.Close();
            }
        }
