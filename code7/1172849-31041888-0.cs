            try
            {
                Assert.AreEqual(expected, result, comment);
            }
            catch
            {
                /// will capture a screenshot of errors
                if (string.IsNullOrEmpty(pictureName) && !string.IsNullOrEmpty(comment))
                {
                    int length = comment.Replace(" ", string.Empty).Length;
                    if (length > 30)
                        length = 30;
                    pictureName = comment.Replace(" ", string.Empty).Substring(0, length);
                }
                pictureName = (pictureName == "" ? Guid.NewGuid().ToString() : pictureName);
                GetScreenShot(pictureName);
         
         // Getscreenshot function capture image for me u need to put your code here(before throw)     
                throw;
            }
        }
