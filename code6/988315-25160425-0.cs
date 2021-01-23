    IAsyncOperation<IReadOnlyList<StorageFile>> async = KnownFolders.MusicLibrary.GetFilesAsync();
               var itemsList = await async;
                   
               foreach (var item in itemsList)
               {
                   var itemProp = item.Properties;
                   var propMusic = await itemProp.GetMusicPropertiesAsync();
                   Music m1 = new Music(propMusic.Title, propMusic.Artist, propMusic.Album, propMusic.Genre.ToString(), propMusic.TrackNumber.ToString(), propMusic.Duration, item.Path);
                   _listMusic.Add(m1);
               }
               return _listMusic;
