    FileInfo[] files = new DirectoryInfo(mypath).GetFiles();
    List<FileInfo> filteredFiles = new List<FileInfo>();
    foreach (FileInfo file in fileInfos)
    {
        string file= fileInfo[i].FullName;
        using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read))
        using (var br = new BinaryReader(stream, Encoding.ASCII))
        {
            byte[] preamble = new byte[132];
            br.Read(preamble, 0, 132);
            if (preamble[128] != 'D' || preamble[129] != 'I' || preamble[130] != 'C' || preamble[131] != 'M')
            {
                if (preamble[0] + preamble[1] != 0008)
                {
                    // skip this file
                    continue;
                }
                // keep the file
                filteredFiles.Add(file);
                // do something else with the file
            }
        }
    }
