    // assuming you have a variable called serializedMessage as the byte array received
    Message ms;
    using (var stream = new MemoryStream())
    {
        var formatter = new BinaryFormatter();
        stream.Write(serializedMessage, 0, serializedMessage.Length);
        stream.Seek(0, SeekOrigin.Begin);
        ms = (Message)formatter.Deserialize(stream);
    }
