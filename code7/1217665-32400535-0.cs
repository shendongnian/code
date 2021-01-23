        foreach (var item in listBox1.Items)
        {
            path = item.ToString();
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(path, "*",
               SearchOption.AllDirectories))
               Directory.CreateDirectory(dirPath.Replace(path, backUpDes));
            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(path, "*.*",
               SearchOption.AllDirectories))
               File.Copy(newPath, newPath.Replace(path, backUpDes), true);
        }
        
