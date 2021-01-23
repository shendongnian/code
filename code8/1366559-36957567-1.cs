       protected void btnTransferFiles_Click(object sender, EventArgs e)
        {
            string sourcePath = Server.MapPath("~/SourceFolder/Images");
            string targetPath = Server.MapPath("~/DestinationFolder/Photos");
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                string fileName = string.Empty;
                string destFile = string.Empty;
                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
        }
