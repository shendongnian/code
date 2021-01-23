    private void btnConvert_Click(object sender, EventArgs e)
    {
        string[] originalImage = Directory.GetDirectories(txtFilePath.Text, "*.*", SearchOption.AllDirectories);
        foreach (var directory in originalImage)
        {
            Debug.WriteLine(directory);
        }
        foreach (string dir in originalImage)
        {
            // The name of the current folder (dir)
            string folderName = dir.Substring(dir.LastIndexOf('\\') + 1); // Ex. "Image1"
            // This will now be "C:\test\FOLDERNAME_converted"
            string folderPath = @"C:\test\" + folderName + @"_converted\"; // Ex. "C:\test\image1_converted\";
            // This can now create the folders
            DirectoryInfo di = Directory.CreateDirectory(folderPath);
            // Below is unchanged for now
            if (Directory.Exists(folderPath))
            {
                DirectoryInfo dInfo = new DirectoryInfo(dir);
                foreach (var filename in dInfo.GetFiles())
                {
                    FileInfo fInfo = new FileInfo(filename.FullName);
                    var fileExtension = fInfo.Extension;
                    var fileOriginalDate = fInfo.CreationTime;
                    if (fileExtension.ToUpper() == ".JPG" || fileExtension.ToUpper() == ".PNG")
                    {
                        using (Bitmap bitmap = new Bitmap(filename.FullName))
                        {
                            string fn = Path.GetFileNameWithoutExtension(filename.FullName);
                            VariousQuality(bitmap, fn, fileExtension,
                                                  fileOriginalDate, folderPath);
                        }
                    }
                }
            }
        }
    }
