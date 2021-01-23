    object myBuffer;
    int myBufferSize;
    AMC1.GetCurrentImage(0, out myBuffer, out myBufferSize) ;
    byte[] returningBytes = new byte[myBufferSize];
    //Add JPEG header to new byte array
    returningBytes[0] =  Convert.ToByte(255);
    returningBytes[1] = Convert.ToByte(216);
    returningBytes[2] = Convert.ToByte(255);
    returningBytes[3] = Convert.ToByte(224);
    returningBytes[4] = Convert.ToByte(0);
    returningBytes[5] = Convert.ToByte(16);
    returningBytes[6] = Convert.ToByte(74);
    returningBytes[7] = Convert.ToByte(70);
    returningBytes[8] = Convert.ToByte(73);
    returningBytes[9] = Convert.ToByte(70);
    //Copy actual image into new byte array
    Buffer.BlockCopy(myBuffer as Array, 10, returningBytes, 10, myBufferSize - 10);
