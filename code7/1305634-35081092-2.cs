    var duplicate = new HashSet<string>();
        foreach (FileInfo file in folderFiles)
        {
            int fileCount = 0;
            StreamWriter sw = null;
            string fileName = Path.GetFileNameWithoutExtension(file.Name);
            string[] brkedfilename = fileName.Split('_');
            string stringToCheck = brkedfilename[3];
            if (folderFiles.Any(d=> d.Name.Split('_')[3] == stringToCheck))
            {
                duplicate.Add(stringToCheck);
            }
        }
        foreach (var s in duplicate)
            sw.WriteLine(s + "  " + "--" + "  " + "Repeated in folder " + " " + folder.Name);
