    string dpath = "D:\\Destination\\";
                string spath = "D:\\Source";
                dynamic flist = Directory.GetFiles(spath);
                foreach (string item in flist)
                {
                    File.Move(item, dpath + new FileInfo(item).Name);
                }
