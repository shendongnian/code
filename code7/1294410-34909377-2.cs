    static byte _header = new byte[9]; //signature, version, flags, headerSize
    
    public void YourStreamMethod()
    {
        int bytesRec = handler.Receive(bytes);
        if (!_headerIsStored)
        {
            //store header
            Buffer.BlockCopy(bytes, 0, _header, 0, 9);
            _headerIsStored = true;
        }
    }
