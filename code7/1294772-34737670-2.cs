            string pictureName;
            string newPictureName;
            List<string> fileNames = new List<string>(); 
            foreach(var name in fileNames)
            {
                if (checkBox.IsChecked)
                {
                    pictureName = "images\\disabled\\" + name + ".png";
                    newPictureName = "images/disabled/" + name + ".png";
                }
                else
                {
                    pictureName = "images\\enabled\\" + name + ".png";
                    newPictureName = "images/enabled/" + name + ".png";
                }
            }
            Records[pictureName].ReplaceContents(imagesPath, newPictureName, content.FileRoot);
