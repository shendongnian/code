            const string testFolder = @"\Test";
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            var path = folderBrowserDialog.SelectedPath;
            if (!Directory.Exists(path)) { return; }
            if (!Directory.Exists(path + testFolder)) { Directory.CreateDirectory(path + testFolder); }
            var fileList = from file in Directory.GetFiles(path) where file.Contains(".txt") select file;
            
            foreach (var f in fileList)
            {
                var fileLines = File.ReadLines(f);
                foreach (var ps in fileLines.Select(l => l.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)))
                {
                    var fname = Path.GetFileName(f);
                    using (var wf = File.CreateText(path + testFolder + @"\" + fname))
                    {
                        foreach (var p in ps)
                        {
                            wf.Write(p);
                            wf.Write(',');
                        }
                        wf.WriteLine();
                    }
                }
            }
