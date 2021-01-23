    public void AddLog (string message, string fn_name)
        {
            string path = @"E:\" + fn_name +".txt";
            if (!File.Exists(path))
            {
                using (File.Create(path))
                using (TextWriter tw = new StreamWriter(path))
                    tw.WriteLine("" + message +"");
            }
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path,true))
                    tw.WriteLine("" + message + "");
            }
        }
