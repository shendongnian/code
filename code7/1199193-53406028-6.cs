     public static class ImageResizeHelper
            {
                public static void SaveAfterResizeImage( this HttpPostedFile 
                                   postedFile,string filePath, string extension)
                {
                    postedFile.SaveAs(filePath);
        
                    var resizeSetting = new ResizeSettings
                    {
                        Width = 500,
                        Height = 500,
                        Format = extension
                    };
            
                    ImageBuilder.Current.Build(filePath,ilePath,resizeSetting);
                }
            }
