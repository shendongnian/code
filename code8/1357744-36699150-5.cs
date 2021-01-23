    var imageList = new List<Image>();
    using (ExcelPackage package = new ExcelPackage(fileInfo))
    {
       /* ... */
             if (File.Exists(imagePath))
             {
                Image ImageToPutInReport;
                // Make a copy of the loaded image and dispose the original
                // so the file is freed
                using(var tempImage = Image.FromFile(imagePath))
                   ImageToPutInReport = new Bitmap(tempImage);
               
                // Add to the list of images we'll dispose later 
                // after we're done
                imageList.Add(ImageToPutInReport);
                var image = ws2.Drawings.AddPicture(imagesLocations[i].Name, ImageToPutInReport);
                image.SetSize(375, 375);
                image.SetPosition(i, 0, 1, 0);
            }
       /* ... */
       package.SaveAs(fileInfo);
    }
    foreach(var img in imageList)
      img.Dispose();
    imageList.Clear();
   
