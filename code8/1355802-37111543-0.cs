    public long chunkMethodCW() 
    {
        int incomingOffset = 0;
        byte[] outboundBuffer = new byte[1024];
        long CW = 0;
        KMP kmp = new KMP(header); // header = pattern in hex
        while(incomingOffset < data.Length)
        {
            int length = Math.Min(outboundBuffer.Length,data.Length - incomingOffset);
            Buffer.BlockCopy(data,incomingOffset,outboundBuffer,0,length);
            incomingOffset += length;
           CW += kmp.match(outboundBuffer);  //this should be uncommented
           //CW++;   I guess this is commented
       }
       return CW;
    }
 
