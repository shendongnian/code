    var arrays = new List<string[]> { s1.Split(','), s2.Split(','), s3.Split(',') };
    int minLength = arrays.Min(arr => arr.Length);  // to be safe, same behaviour as Zip
    IEnumerable<Info> InfoSrc = Enumerable.Range(0, minLength)
     .Select(i => new Info
     {
         Name = arrays[0][i],
         Num = arrays[1][i],
         Prop3 = arrays[2][i]
     });
