    byte checksum=0x00;
    for(int i=3;i<request.Length;i++)
    {
        checksum += xbeeFrame[i]; //xbeeFrame is the array where are stored the bytes' frame
    }
    
    //checksum &= 0xff; // This one is done implicit through the byte type
    checksum = 0xff - checksum; // Noted in your example
     
    Console.WriteLine("The checksum is :"+checksum.ToString("X"));
    xbeeFrame[3 + request.Length] = checksum;
