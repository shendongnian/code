            foreach (string line in File.ReadLines(YourCSVFilePath))
            {
                string[] strArr = line.Split(',');
                foreach (string str in strArr)
                {
                    string cleanedStr = Regex.Replace(str, "[^a-zA-Z0-9]", "");
                    //Do your stuff with the cleanedStr here
                }
            }
