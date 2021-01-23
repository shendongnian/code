     TcpClient t = new TcpClient("localhost", 4444);
     NetworkStream s = t.GetStream();
     string reqStr = "<request><parameters><param>7</param><param>15</param></parameters></request>";
     XmlDocument req = new XmlDocument();
     req.LoadXml(reqStr);
     req.Save(s);
     var bytes = new List<byte>();
     do
     {
         var b = (byte)s.ReadByte();
         bytes.Add(b);
     } while (s.DataAvailable);
     XmlDocument resp = new XmlDocument();
     resp.Load(new MemoryStream(bytes.ToArray()));
     Console.WriteLine(resp.OuterXml);
