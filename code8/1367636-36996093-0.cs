     string path = @"d:\\dummyfolder";
            for (int i = 0; i < 17; i++)
            {
                string _folderPath = string.Format("{0}\\{1}", path, i);                
                if (!Directory.Exists(_folderPath))
                {
                    //creating folder
                    Directory.CreateDirectory(_folderPath);
                    //creating text file
                    string _filePath = string.Format("{0}\\{1}\\{1}.txt", path, i);                    
                    string text = i + " " + "Content of the text file ";
                    File.WriteAllText(_filePath, text);
                }
            }
