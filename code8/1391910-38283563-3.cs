    void MergeSort(string fileOne, string fileTwo)
    {
        string result = CreateUniqueFilename();
        using(var srOne = new StreamReader(fileOne, Encoding.UTF8))
        {
            using(var srTwo = new StreamReader(fileTwo, Encoding.UTF8))
            {
                // I left the actual field parsing as an excersise for the reader
                string lineOne, lineTwo; // fieldOne, fieldTwo;
                using(var target = new StreamWriter(result))
                {
                    lineOne = srOne.ReadLine();
                    lineTwo = srTwo.ReadLine();
                    // naive field parsing
                    // fieldOne = lineOne.Split(';')[4];
                    // fieldTwo = lineTwo.Split(';')[4];
                    while( 
                        !String.IsNullOrEmpty(lineOne) || 
                        !String.IsNullOrEmpty(lineTwo))
                    {
                        // use your parsed fieldValues here 
                        if (lineOne != null && (lineOne.CompareTo(lineTwo) < 0 || lineTwo==null))
                        {
                            target.WriteLine(lineOne);
                            lineOne = srOne.ReadLine();
                            // fieldOne = lineOne.Split(';')[4];
                        } 
                        else
                        {
                            if (lineTwo!=null)
                            {
                                target.WriteLine(lineTwo);
                                lineTwo = srTwo.ReadLine();
                                // fieldTwo = lineTwo.Split(';')[4];
                            }
                        }
                    }
                }
            }
        }
        // all is perocessed, remove the input files.
        File.Delete(fileOne);
        File.Delete(fileTwo);
    }
