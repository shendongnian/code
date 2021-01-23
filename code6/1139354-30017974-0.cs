    void ReadFromPort(SerialPort p)
    {
         Stream s = p.BaseStream;
         s.ReadTimeout = 20;
         // 1/50th of a second and 10 serial bits per byte
         byte[] buffer = new byte[p.BaudRate / 500];
         ReadSerialStream(s, buffer);
    }
    void async ReadSerialStream(Stream s, byte[] buffer)
    {
         int bytesRead = await s.ReadAsync(buffer, 0, buffer.Length);
         string indata = Encoding.ASCII.GetString(
                                  buffer.Take(bytesRead).Where(b => b != 0).ToArray());
         port1out.Text += indata + Environment.Newline;
         ReadSerialStream(s, buffer);
         // or use an infinite while loop. With async methods, recursion is safe
    }
