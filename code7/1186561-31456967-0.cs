            DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            List<FileInfo> files = directory.GetFiles().ToList();
            List<FileInfo> unAllowed = files.FindAll(f => !allowedFiles.Contains(f.Name));
            if (unAllowed.Count > 0)
            {
                string notAllowedFiles = "";
                unAllowed.ForEach(f => notAllowedFiles += f.Name + ",");
                Message.Warning("Unallowed files found ! Please remove " + notAllowedFiles);
                return;
            }
