    var newMachine = Factory.NewMachine();
    var connected = newMachine
        .Init()
        .Connect(connectionString);
    connected.GetValue("test");
    ...
    connected.Disconnect();
