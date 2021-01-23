    var allowedExtensions = new [] { ".MP3", ".MP4", ".MKV" };
    //  If All of the filename extensions are contained in allowedExtensions, 
    //  set dropEnabled to true. 
    dropEnabled = filenames.All(fn =>
            allowedExtensions.Contains(System.IO.Path.GetExtension(fn).ToUpperInvariant())
        );
