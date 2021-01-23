        TagLib.File tagFile = TagLib.File.Create("C:\\Users\\Dom\\Desktop\\song.mp3"); Tag t = tagFile.GetTag(TagTypes.Id3v2);
        tagFile.RemoveTags(TagTypes.Id3v2); Tag tags = tagFile.GetTag(TagTypes.Id3v2);
        tagFile.GetTag(TagTypes.Id3v2, true); tagFile.Save();
        tagFile = TagLib.File.Create("C:\\Users\\Dom\\Pictures\\picture.png"); tags = t;
    
        tagFile.GetTag(TagTypes.Id3v2).Pictures = new IPicture[] { new Picture("D:\\a.jpg") { MimeType = "image/jpeg", Type = PictureType.FrontCover } };
        tagFile.Tag.Album = "Album 1";
        tagFile.GetTag(TagTypes.Id3v2).Track = 0;
        tagFile.Tag.Year = 1990;
        tagFile.Save();
