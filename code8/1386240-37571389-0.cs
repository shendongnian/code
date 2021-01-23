    var toRead = serial.BytesToRead();
    for (int i=0; i < toRead; i++)
    {
        // where msgArray is an array for storing the incoming bytes
        // and idx is the current idx in that array
        msgArray[idx] = serial.ReadByte();  // this should be quick, because it's already in the buffer
        if (msgArray[idx] = newLineChar)    // whatever newLineChar you are using
        {
            // Read your string
            var msg = Encoding.ASCII.GetString(msgArray,0,idx);   // or whatever encoding you 
                                                                  // are using
            idx = 0;
        }
        else
        {
           idx++;
        }
    }
    
