        private string ParseHist(string file)
        {
            using (var f = File.Open(file, FileMode.Open))
            {
                using (var br = new BinaryReader(f))
                {
                    // read 4 bytes as an int
                    var first = br.ReadInt32();
                    // read integer / zero ended byte arrays as string
                    var lead = br.ReadInt32();
                    // until we have 4 zero bytes
                    while (lead != 0)
                    {
                        var user = ParseString(br);
                        Trace.Write(lead);
                        Trace.Write(":");
                        Trace.Write(user.Length);
                        Trace.Write(":");
                        Trace.WriteLine(user);
                        lead = br.ReadInt32();
                        // weird special case
                        if (lead == 2)
                        {
                            lead = br.ReadInt32();
                        }
                    }
                    // at the start of the html block
                    var htmllen = br.ReadInt32();
                    Trace.WriteLine(htmllen);
                    // parse the html
                    var html = ParseString(br);
                    Trace.Write(len);
                    Trace.Write(":");
                    Trace.Write(html.Length);
                    Trace.Write(":");
                    Trace.WriteLine(html);
                    // other structures follow, left unparsed
                    return html.ToString();
                }
            }
        }
        // a string seems to be ascii encoded and ends with a zero byte.
        private static string ParseString(BinaryReader br)
        {
            var ch = br.ReadByte();
            var sb = new StringBuilder();
            while (ch != 0)
            {
                sb.Append((char)ch);
                ch = br.ReadByte();
            }
            return sb.ToString();
        }
