    foreach (var item in fileDictionary)
            {
                var tempFileList = new List<string>();
                foreach (var file in fileArray)
                {
                    
                    if (!Array.Exists(item.Value, element => element.Contains(file + today)))
                    {
                        tempFileList.Add(file + today);
                    }
                }
                resultDictionary.Add(item.Key, tempFileList);
          
            }
