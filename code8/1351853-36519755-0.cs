    Byte [] bytes = File.ReadAllBytes(this.PathName);
                MemoryStream stream = new MemoryStream(bytes);
                List<Byte> buffer = new List<Byte>();
                Byte ph = Convert.ToByte(0);
                while (stream.Position != stream.Length)
                {
                    if ((ph = Convert.ToByte(stream.ReadByte())) != Convert.ToByte(10))
                        buffer.Add(ph);
                    else
                    {
                        this.lines.Items.Add(Encoding.ASCII.GetString(buffer.ToArray()));
                        buffer.Clear();
                    }
                }
                this.lines.Items.Add(Encoding.ASCII.GetString(buffer.ToArray()));
