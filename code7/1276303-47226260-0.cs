    public ActionResult Product_Delete()
        {
            string idnumber = "07";
            string path1 = @"~/Content/Essential_Folder/attachments_AR/" + idnumber;
            DirectoryInfo attachments_AR = new DirectoryInfo(Server.MapPath(path1));
            EmptyFolder(attachments_AR);
            if (attachments_AR.Exists && IsDirectoryEmpty(attachments_AR.FullName))
                attachments_AR.Delete();
            
        }
        private static void EmptyFolder(DirectoryInfo directory)
        {
            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo subdirectory in directory.GetDirectories())
            {
                EmptyFolder(subdirectory);
                subdirectory.Delete();
            }
        }
        public static bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
