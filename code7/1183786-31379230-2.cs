            //Create a dictionary that holds the file name with it's size
            Dictionary<string, long> FileNameAndSizes = new Dictionary<string, long>();
            
            //Key of dictionary will contain file name
            //Value of dictionary will contain file size
            FileNameAndSizes.Add("file1.dll", 17662);
            FileNameAndSizes.Add("file2.dll", 19019);
            //Iterate through the dictionary
            foreach (var item in FileNameAndSizes)
            {
                //Look for file existance
                if (File.Exists(Directory.GetCurrentDirectory() + "\\dll\\" + item.Key))
                {
                    FileInfo f = new FileInfo(Directory.GetCurrentDirectory() + "\\dll\\" + item.Key);
                    var s1 = f.Length;
                    //Compare the current file size with stored size
                    if (s1 != item.Value)
                    {
                        MessageBox.Show(f.Name + "modified DLL file, please change it to original");
                    }
                }
            }
