        string[] installfiles = Directory.GetFiles(Path.GetDirectoryName(filePath));
            string[] subfolders = Directory.GetDirectories(Path.GetDirectoryName(filePath));
            string appdatafolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            int i = 0;
            foreach (string file in installfiles)
            {
                string fileName = Path.GetFileName(file);
                string fileextension = Path.GetExtension(fileName);
                if (!Directory.Exists(appdatafolder))
                {
                    Directory.CreateDirectory(appdatafolder);
                }
                    File.Copy(filePath + fileName, appdatafolder + fileName, true);
                if (subfolders.Length >= 0 && i < subfolders.Length)
                {
                    string[] subfolderfiles = Directory.GetFiles(subfolders[i]);
                    string foldername = Path.GetFileName(subfolders[i]);
                    i++;
                    foreach (string subfiles in subfolderfiles)
                    {
                        string subfilesname = Path.GetFileName(subfiles);
                        File.Copy(filePath + fileName, appdatafolder + foldername + "_" + subfilesname, true);
                    }
                }
            }
        
