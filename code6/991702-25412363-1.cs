    public string sub_dir(string path)
            {
                
                string[] direct = Directory.GetDirectories(path);
                string s = direct[0];
                return s;
            }
