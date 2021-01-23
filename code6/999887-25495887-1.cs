    int Count = 0;
    foreach (string icon in listIcon)
    {
        var LoadedImage = LoadImage(icon);
        LoadedImage.ImageIndex = Count;
		imglstGames.Images.Add(LoadedImage); // Download, then convert to bitmap
        Count++;
    }
