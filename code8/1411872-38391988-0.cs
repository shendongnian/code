    //TODO initialize the serialConnection and open it
    //TODO specific commands...
    serialConnection.WriteLine("AT+CPIN=\"1234\""); // replace according to your real situation
    var response = serialConnection.ReadExisting();
    Console.WriteLine("pin resp: " + response);
    Thread.Sleep(200);
    //TODO other specific commands?
    serialConnection.Write("whatever");
    //Thread.Sleep(200); uncomment this if it helps
    serialConnection.Write(new byte[]{26}, 0, 1); // or Write("\u001A")
    response = serialConnection.ReadExisting();
    Console.WriteLine("ctrl-z resp: {0}", response);
    //closing stuff, etc...
