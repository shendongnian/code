            string pictureName;
            string newPictureName;
            for (int i = 100; i <= 1000; i++)
            {
                if (checkBox.IsChecked)
                {
                    pictureName = "images\\disabled\\picture" + i + ".png";
                    newPictureName = "images/disabled/picture" + i + ".png";
                }
                else
                {
                    pictureName = "images\\enabled\\picture" + i + ".png";
                    newPictureName = "images/enabled/picture" + i + ".png";
                }
            }
            Records[pictureName].ReplaceContents(imagesPath, newPictureName, content.FileRoot);
