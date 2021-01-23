        try
        {
            CopyAll(dirSource, dirTarget);
            SaveLog(target + @"\log.txt");
            ClearLog();
            //...
        }
        private void SaveLog(string filename)
        {
            if (logList.Count > 0)
            {
                FileStream fs = File.Open(target + @"\log.txt", FileMode.Create);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (string error in logList)
                    {
                        sw.WriteLine(error);
                    }
                }
            }
        }
