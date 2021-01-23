    private string AppendFileNumberIfExists(SPWeb rootWeb, SPFolder folder, string file)
        {
            if (rootWeb.GetFile(file).Exists) 
            {
                string fileName = Path.GetFileNameWithoutExtension(file); // The file name with no extension. 
                int fileVersionNumber = 0;
                                           
                do
                {
                    var version = "_v";
                    fileVersionNumber += 1;
                    file = SPUrlUtility.CombineUrl(folder.Url, 
                                string.Format("{0}{1}{2}{3}", 
                                                fileName,
                                                version,
                                                fileVersionNumber,
                                                ".csv" ));       
                }
                while (rootWeb.GetFile(file).Exists); // As long as the file name exists, keep looping. 
            }
            return file;
     }
