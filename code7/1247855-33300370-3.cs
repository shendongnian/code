    FileStream fs = GetMyFile(); // todo
    if (!fs.CanSeek)
        throw new NotSupportedException("sorry");
    long posCurrent = fs.Position;          // save current position
    int posHello = ReadInt32(fs);           // read position of "hello"
    fs.Seek(posHello, SeekOrigin.Begin);    // seeking to hello
    string hello = ReadString(fs, '\n');    // reading hello
    fs.Seek(posCurrent, SeekOrigin.Begin);  // seeking back
    
