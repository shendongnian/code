    var allowedExtensions = new [] { ".MP3", ".MP4", ".MKV" };
    foreach (var fn in filenames)
    {
        var ext = System.IO.Path.GetExtension(fn).ToUpperInvariant();
        if (!allowedExtensions.Contains(ext))
        {
            dropEnabled = false;
            break;
        }
    }
