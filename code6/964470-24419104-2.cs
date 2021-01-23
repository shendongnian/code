    void PlayImages()
    {
        string testImageFolder = "...";
        DirectoryInfo d = new DirectoryInfo(testImageFolder);
        FileInfo[] Files = d.GetFiles("*.tif");
        List<string> tiffImage = new List<string>();
        for (int n = 0; n < Files.Length; n++)
        {               
            tiffImage.Add(Files[n].Directory.ToString() + "\\" + Files[n].Name);   
        }
        vm.TiffFiles = tiffImage;
    }
