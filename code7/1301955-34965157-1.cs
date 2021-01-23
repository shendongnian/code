        public IList<string> HighestVersion(int topCount)
        {
            List<VersionFolder> vfList = new List<VersionFolder>
           {
               new VersionFolder(1, "A"),
               new VersionFolder(4, "B"),
               new VersionFolder(3, "C")
           };
            vfList = vfList.OrderBy(v => v.Version).Take(topCount).ToList();
            foreach (VersionFolder versionFolder in vfList)
            {
                Console.WriteLine(versionFolder.FolderDir);
            }
            //return folderDir only
            return vfList.Select(v=>v.FolderDir).ToList();
        }
