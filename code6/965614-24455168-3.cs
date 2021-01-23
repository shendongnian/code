    NetworkStream networkStream = socketForServer.GetStream();
    System.IO.BinaryWriter binaryWriter = new System.IO.BinaryWriter(networkStream);
    
    //------
    int messageSource = 0;
    int messageDesitination = 0;
    int interlockingId = 0;
    int trackId = 0;
    int trainId = 2;
    int direction = 0;
    int messageType = 0;
    int informationType = 0;
    int dateTime = 0;
    
    foreach (Sensor LeftSensorList in LeftSensor)
    {
        binaryWriter.Write(messageSource);
        binaryWriter.Write(messageDesitination);
        binaryWriter.Write(interlockingId);
        binaryWriter.Write(trackId);
        binaryWriter.Write(trainId);
        binaryWriter.Write(direction);
        binaryWriter.Write(messageType);
        binaryWriter.Write(informationType);
        binaryWriter.Write(dateTime);
    
        binaryWriter.Flush();
                        
        Thread.Sleep(4000);
    }
    //Hint : Changes here
    binaryWriter.Close();
