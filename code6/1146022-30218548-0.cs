            try
            {
            string PATH = @"C:\YourFolderPath";
            DirectoryInfo Dir = new DirectoryInfo(PATH);
            FileInfo[] FileList = Dir.GetFiles("*.xls*", SearchOption.AllDirectories );
            foreach (FileInfo FI in FileList )
            {
            Console.WriteLine(FI.FullName);
            }
            }
            catch (Exception ex)
            {
            Console.WriteLine(ex.Message );
            }
