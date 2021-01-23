    private void Init(Stream stream, ZipArchiveMode mode, Boolean leaveOpen)
    {
        Stream extraTempStream = null;
        try
        {
            _backingStream = null;
            //check stream against mode
            switch (mode)
            {
                case ZipArchiveMode.Create:
                    // (SNIP)
                case ZipArchiveMode.Read:
                    if (!stream.CanRead)
                        throw new ArgumentException(SR.ReadModeCapabilities);
                    if (!stream.CanSeek)
                    {
                        _backingStream = stream;
                        extraTempStream = stream = new MemoryStream();
                        _backingStream.CopyTo(stream);
                        stream.Seek(0, SeekOrigin.Begin);
                    }
                    break;
                case ZipArchiveMode.Update:
                    // (SNIP)
                default:
                    // (SNIP)
            }
         // (SNIP)
    }
