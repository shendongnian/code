    var sb = new StringBuilder();
    while(mStream.DataAvailable())
    {
        byte[] received = new byte[1024];
        mStream.Read(received, 0, received.Length);
        sb.Append(Encoding.ASCII.GetString(recieved));
    }
    var receivedString = sb.ToString();
    _screenWriterCallBT("Received: " + receivedString + "via bluetooth");
    ParseJson parseJson = new ParseJson();
    JsonReturn = parseJson.InitialParsing(revievedString); //parse message
