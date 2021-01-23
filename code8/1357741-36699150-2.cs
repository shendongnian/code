    using(var ImageToPutInReport = Image.FromFile(imagePath))
    {
      var image = ws2.Drawings.AddPicture(imagesLocations[i].Name, ImageToPutInReport);
      image.SetSize(375, 375);
      image.SetPosition(i, 0, 1, 0);
    }
