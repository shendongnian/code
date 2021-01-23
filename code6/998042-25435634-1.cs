            if(!IsFileLocked(fi)){
                if (!File.Exists(destinationFileName))
                {
                    fi = new FileInfo(e.FullPath);
                    fi.MoveTo(destinationFileName);
                }
                else
                {
                    fi = new FileInfo(e.FullPath);
                    string fileName = destinationFileName + random.Next();
                    fi.MoveTo(fileName);
                }
                fi = null;
            }
