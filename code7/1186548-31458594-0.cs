    int listcount = (int)Math.Ceiling(totalsize / listlimit); //500kb
                List<FileInfo> fileInfoList = new List<FileInfo>();
    
                List<string>[] lists = new List<string>[listcount];
    
                double[] memorytotals = new double[listcount]; // this array will keep track of what the file size total is in each of the arrays.
    
                foreach (string file in filelist)
                {
                    fileInfoList.Add(new FileInfo(file));         // Add all the FileInfo to a list to order it                      
                }
    
                fileInfoList.OrderBy(r => r.Length);
    
    
                foreach (FileInfo fileInfo in fileInfoList)
                {
                    double size = fileInfo.Length;
    
                    // flag for only add a file one time
                    bool flag = true;
    
                    
                    for (int j = 0; j < memorytotals.Length; j++)
                    {
    
                        // check if the file fits in the list
                        if (memorytotals[j] + size < listcount && flag)
                        {
                            memorytotals[j] = memorytotals[j] + size;
                            lists[j].Add(fileInfo.FullName);
                            flag = false;
                        }
                    }
                }
