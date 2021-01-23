       public List<string> Init()
       {
           List<VersionFolder> vfList = new List<VersionFolder>
           {
               new VersionFolder(1, "A"),
               new VersionFolder(4, "B"),
               new VersionFolder(3, "C")
           };
           return vfList.OrderBy(v => v.Version).Select(f=>f.FolderDir).Take(4).ToList();
       }
