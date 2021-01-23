    const char quote = '\'';
    const char escape = '\\';
    using (var dumpOut = new FileStream("dump_out.txt", FileMode.Create, FileAccess.Write))
    using (var dumpIn = new FileStream("dump_in.txt", FileMode.Open, FileAccess.Read))
    {
        bool inquotes = false;
        byte previousByte = 0;
        var stringBytes = new List<byte>();
        while (true)
        {
            int readByte = dumpIn.ReadByte();
            if (readByte == -1) break;
            var b = (byte) readByte;
            if (b == quote && previousByte != escape)
            {
                if (inquotes) // closing quote
                {
                    var buffer = stringBytes.ToArray();
                    stringBytes.Clear();
                    byte[] converted = Encoding.Convert(Encoding.Default, Encoding.UTF8, buffer);
                            
                    dumpOut.Write(converted, 0, converted.Length);
                    dumpOut.WriteByte(b);
                }
                else // opening quote
                {
                    dumpOut.WriteByte(b);
                }
                inquotes = !inquotes;
                continue;
            }
            previousByte = b;
            if (inquotes)
                stringBytes.Add(b);
            else
                dumpOut.WriteByte(b);
        }
    }
