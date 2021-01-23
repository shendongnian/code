    var temp = imagesLocations[i].Tests.FirstOrDefault(t => t.IsReference).ImagePath;
    if (File.Exists(temp))
    {
        var temp2 = Image.FromFile(temp);
        var image = ws2.Drawings.AddPicture(imagesLocations[i].Name, temp2);
        image.SetSize(375, 375);
        image.SetPosition(i, 0, 1, 0);
    }
