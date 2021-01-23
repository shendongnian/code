        public void SendString(string str)
        {
             //ns is a NetworkStream class parameter
            //logger.Output(">> sendind data to client ...", LogLevel.LL_INFO);
            try
            {
                var buf = Encoding.UTF8.GetBytes(str);
                int frameSize = 64;
                var parts = buf.Select((b, i) => new { b, i })
                                .GroupBy(x => x.i / (frameSize - 1))
                                .Select(x => x.Select(y => y.b).ToArray())
                                .ToList();
                for (int i = 0; i < parts.Count; i++)
                {
                    byte cmd = 0;
                    if (i == 0) cmd |= 1;
                    if (i == parts.Count - 1) cmd |= 0x80;
                    ns.WriteByte(cmd);
                    ns.WriteByte((byte)parts[i].Length);
                    ns.Write(parts[i], 0, parts[i].Length);
                }
                ns.Flush();
            }
            catch (Exception ex)
            {
                _srv.LogError(">> " + ex.Message);
            }
        }
    
