    var ms = new Message();
    ms.type = 1;
    ms.us = usernameTextBox.Text;
    ms.pas = usernameTextBox.Text;
    byte[] serializedMessage;
    var formatter = new BinaryFormatter();
    using (var stream = new MemoryStream())
    {
        formatter.Serialize(stream, ms);
        serializedMessage = ms.ToArray();
    }
    // now serializedMessage is a byte array to be sent
