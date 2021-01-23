    public void Send(SerialPort serialPort1)
        {
            if (serialPort1.IsOpen) 
            {
                var content = new List<byte>();
                content.Add(2);
                content.AddRange(Encoding.ASCII.GetBytes(CommandText));
                content.Add(3);
                byte[] buffer = content.ToArray();
                serialPort1.Write(buffer, 0, buffer.Length);
            }
        }
