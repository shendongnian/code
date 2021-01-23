    Byte[] byteMessage = Encoding.Unicode.GetBytes(messageTextBox.Text);
    Byte[] lengthPrefix = BitConverter.GetBytes(byteMessage.Length);
    if (BitConverter.IsLittleEndian)
         Array.Reverse(lengthPrefix);
    
    NetworkStream stream = client.GetStream();
    BinaryWriter writer = new BinaryWriter(stream);
    // BinaryWriter.Write(Int32) writes in little-endian only,
    // so still have to use Write(Byte[])...
    writer.Write(lengthPrefix); 
    writer.Write(byteMessage)
    writer.Flush();
    
    stream.Close();
    client.Close();
