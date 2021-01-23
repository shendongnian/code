    var reader = new BinaryReader(File.Open(fileName, FileMode.Open));
    while not end of file
    {
        // read header. Probably want to read characters one at a time here.
        StringBuilder sb = new StringBuilder();
        char c;
        do
        {
            c = reader.ReadChar();
            sb.Append(c);
        } while c != ']';
        var header = sb.ToString();
        // parse header. One of the fields you get is SizeInBytes
        var imageBytes = reader.ReadBytes(SizeInBytes);
        var stream = new MemoryStream(imageBytes);
        var jpeg = Image.FromStream(stream);
        // do what you want with the jpeg here.
        
        // the file should be positioned at the start of the next header
        // so just do it all again until no more data.
    }
