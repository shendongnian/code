    TcpClient client = new TcpClient(hostTextBox.Text, int.Parse(portTextBox.Text));
    
    Byte[] byteMessage = Encoding.Unicode.GetBytes(messageTextBox.Text);
    Byte[] lengthPrefix = BitConverter.GetBytes(byteMessage.Length);
    if (BitConverter.IsLittleEndian)
         Array.Reverse(lengthPrefix);
    
    NetworkStream stream = client.GetStream();
    stream.Write(lengthPrefix, 0, lengthPrefix.Length);
    stream.Write(byteMessage, 0, byteMessage.Length);
    
    stream.Close();
    client.Close();
