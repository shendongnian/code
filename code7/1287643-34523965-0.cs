    string dir = Directory.GetDirectories(@"D:\","App_data_payroll").FirstOrDefault();
    string targetPath = "D:\CopyToFolder\";
    if (System.IO.Directory.Exists(dir))
    {
        string[] files = System.IO.Directory.GetFiles(dir);
        // Copy the files and overwrite destination files if they already exist.
        foreach (string s in files)
        {
            var fileName = System.IO.Path.GetFileName(s);
            var destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.File.Copy(s, destFile, true);
        }
    }
