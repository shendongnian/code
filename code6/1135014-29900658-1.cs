            #region get signed in user's photo
            if (signedInUser.ObjectId != null)
            {
                IUser sUser = (IUser)signedInUser;
                IStreamFetcher photo = (IStreamFetcher)sUser.ThumbnailPhoto;
                try
                {
                    DataServiceStreamResponse response =
                    photo.DownloadAsync().Result;
                    Console.WriteLine("\nUser {0} GOT thumbnailphoto", signedInUser.DisplayName);
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nError getting the user's photo - may not exist {0} {1}", e.Message,
                        e.InnerException != null ? e.InnerException.Message : "");
                }
            }
            #endregion
