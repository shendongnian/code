    var content = new List<byte>();
    content.Add(2); // ASCII STX
    content.AddRange(Encoding.ASCII.GetBytes("01P00104##"));
    content.Add(3); // ASCII ETX
    byte[] buffer = content.ToArray();
    serialPort1.Write(buffer, 0, buffer.Length);
