        for (var i = 0; i < VisualTreeHelper.GetChildrenCount(PlayerImagesGrid); i++)
        {
            var child = VisualTreeHelper.GetChild(PlayerImagesGrid, i);
            var image = child as Image;
            if (image != null)
            {
                one.Images.Add(image);
            }
        }
