    public void DirCopy(string SourcePath, string DestinationPath)
        {
            if (Directory.Exists(DestinationPath))
            {
                System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(DestinationPath);
                foreach (FileInfo file in downloadedMessageInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            
            //=================================================================================
            string[] directories = System.IO.Directory.GetDirectories(SourcePath, "*.*", SearchOption.AllDirectories);
            string[] files = System.IO.Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories);
            totalPB.Minimum = 0;
            totalPB.Maximum = directories.Length;
            totalPB.Value = 0;
            totalPB.Step = 1;
            subTotalPB.Minimum = 0;
            subTotalPB.Maximum = directories.Length;
            subTotalPB.Value = 0;
            subTotalPB.Step = 1;
            Parallel.ForEach(directories, dirPath =>
            {
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));
                subTotalPB.PerformStep();
            });
            Task.Run(() => 
            {
                Parallel.ForEach(files, newPath =>
                {
                    File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
                    totalPB.PerformStep();
                });
            });
            
        }
