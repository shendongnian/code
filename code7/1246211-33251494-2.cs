    ImageList imageList = new ImageList();
    imageList.Images.Add("key1", Image.FromFile("pathtofile"));
    imageList.Images.Add("key2", Image.FromFile("pathtofile"));
    
    tcMain.ImageList = imageList;
    tcMain.TabPages[0].ImageIndex = 1;
    tcMain.TabPages[1].ImageIndex = 0;
