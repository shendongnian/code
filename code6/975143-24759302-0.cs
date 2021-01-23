    FileStream fs = new FileStream("fullFileName");
    
    fs.Seek(startByte, SeekOrigin.Current)
    for (long offset = startByte; offset < fs.Length; offset++)
    {
         fs.Seek(-1, SeekOrigin.Current);
         char value = (char)((byte)fs.ReadByte());
        .
        .
        .
    //To determine the end of each line you can use the conditions below
         if (value == 0xA)//  hex \n
         {
              if (offset == fs.Length)
                  continue;
                            
         }
         else if (value == 0xD)// hex \r
         {
             if (offset == fs.Length - 1)
                  continue;
         }
                       
    }
