    foreach (AccessListEntry itm in StorageApplicationPermissions.FutureAccessList.Entries)
                {
                    if (itm.Metadata == "Test")
                    {
                        StorageFile actualFile = await StorageApplicationPermissions.FutureAccessList.GetFileAsync(itm.Token);
                        var stream = await actualFile.OpenAsync(FileAccessMode.Read);
 
                        mediaPlayer.SetSource(stream, actualFile.ContentType);
                        mediaPlayer.Play();
                    }
                }
