     System.IO.FileStream fs = System.IO.File.OpenRead(f.FullName);
     long length = fs.Length;
     byte[] stream = new byte[length];
     fs.Read(stream, 0, (int)length);
     string json = System.Text.Encoding.UTF8.GetString(stream);
     var N = JSONNode.Parse(json);
