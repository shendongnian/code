    public string ShowContent(string path)
        {
            var result = string.Empty;
            var tmpLine = string.Empty;
            if (File.Exists(path))
            {
                using(var sr = new StreamReader(path, Encoding.UTF8))
                {
                     while((tmpLine = sr.ReadLine()) != null)
                     {
                         result += tmpLine + "\n\r";
                     }
                }
            }
            else
            {
                Response.Write("file does not exist!");
            }
            txtFileCOntents.Text = result ;
        }
