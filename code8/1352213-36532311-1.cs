    string genre = "Hip-Hop, Rock"; // Change as required... You can also provide a single genre or even more than 2.
    var matchingFiles = Directory.GetFiles(@"Folder\SubFolder", "*.mp3", SearchOption.AllDirectories).Where(x => { var f = TagLib.File.Create(x); return ((TagLib.Id3v2.Tag) f.GetTag(TagTypes.Id3v2)).JoinedGenres == genre; });
    foreach (string f in matchingFiles)
    {
         System.IO.File.Move(f, Path.Combine(@"D:\NewFolder", new FileInfo(f).Name));
    }
