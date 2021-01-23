    var buf = new byte[400];
    using (var ms = new MemoryStream(buf))
    using (var bw = new BinaryWriter(ms)) {
        for (int i = 0 ; i != 100 ; i++) {
            bw.Write(2*i+3);
        }
    }
    // At this point buf contains the bytes of 100 ints
