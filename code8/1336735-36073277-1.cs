    var memstr = new MemoryStream();
    using (var i = new CryptoStream(memstr.....)
    {
       i.Write(some data);
       var buf = memstr.GetBuffer();
       client.GetStream().Write(buf);
    }
    var inp = client.GetStream.Read(..);
    var memstr2 = new MemoryStream(inp);
    using (var o = new CryptoStream(memstr2,...))
    {
       var x = memstr2.Read();
    }
    
