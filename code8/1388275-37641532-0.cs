    public string ShowContent(string path)
        {
            var result = string.Empty;
    
            if (File.Exists(path))
            {
                using(var sr = new StreamReader(path, Encoding.UTF8))
                {
                     result = sr.ReadToEnd();
                     sr.Close();
                }
            }
            else
            {
                Response.Write("file does not exist!");
            }
            txtFileCOntents.Text = result ;
        }
