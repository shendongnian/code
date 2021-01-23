    Byte[] GetHash(SomeClass someClass) {
      if (someClass == null)
        throw new ArgumentNullException("someClass");
      var byteBuffers = GetStrings(someClass).Select(
        s => String.IsNullOrEmpty(s)
             ? new Byte[0] : Encoding.UTF8.GetBytes(s.ToUpperInvariant())
      );
      var bytes = byteBuffers
        .Aggregate(new List<Byte>(), (l, b) => { l.AddRange(b); return l; })
        .ToArray();
      using (var sha1 = new SHA1Managed())
        return sha1.ComputeHash(bytes);
    }
    
    IEnumerable<String> GetStrings(SomeClass someClass) {
      yield return someClass.Str1;
      yield return someClass.Str2;
      yield return someClass.Str3;
      yield return someClass.Str4;
    }
