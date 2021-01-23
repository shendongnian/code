    Client code:
    
    binaryWriter.Write(10);
    binaryWriter.Write(20);
    Server code:
    int value1 = binaryReader.ReadInt32(); //10
    int value2 = binaryReader.ReadInt32(); //20
