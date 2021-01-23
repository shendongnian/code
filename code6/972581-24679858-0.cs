            var directory = new System.IO.DirectoryInfo(@"C:\Documents");
            var inner_files = directory.EnumerateFiles();
            var inner_directories = directory.EnumerateDirectories();
            List<DataStructure> datasource = new List<DataStructure>();
            foreach (var item in inner_directories)
            {
                datasource.Add(new DataStructure { Name = item.Name, Type = "Folder", ImageUrl = "link to folder Image" });
            }
            
            foreach (var item in inner_files)
            {
                datasource.Add(new DataStructure { Name = item.Name, Type = item.Extension, ImageUrl = "link to file Image" });
            }
