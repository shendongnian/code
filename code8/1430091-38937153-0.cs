     static public string CombineFilesText(string mainPath, string clientPath)
        {
            string returnText = "";
            FileStream mfs = File.OpenRead(mainPath);
            using (StreamReader sr = new StreamReader(mfs))
            {
                returnText += sr.ReadToEnd();
            }
            FileStream cfs = File.OpenRead(clientPath);
            using (StreamReader sr = new StreamReader(cfs))
            {
                returnText += sr.ReadToEnd();
            }
            return returnText;
        }
