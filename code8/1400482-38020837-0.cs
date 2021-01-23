    byte[] source = // ...
    string packet = String.Join(" ", source.Select(b => b.ToString("X2")));
    // chunks is of type IEnumerable<IEnumerable<byte>>
    var chunks = Regex.Split(packet, @"(?=47)")
                 .Select(c =>
                     c.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                     .Select(h => Convert.ToByte(h, 16)));
