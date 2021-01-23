    var hs = new HashSetEx<string>();
    string str = "Hello";
    string st1 = str.Substring(2);
    hs.Add(st1);
    string st2 = str.Substring(2);
    // st1 and st2 are distinct strings!
    if (object.ReferenceEquals(st1, st2))
    {
        throw new Exception();
    }
    string stFinal = hs.AddOrGet(st2);
    if (!object.ReferenceEquals(stFinal, st1))
    {
        throw new Exception();
    }
    string stFinal2;
    bool result = hs.TryGet(st1, out stFinal2);
    if (!object.ReferenceEquals(stFinal2, st1))
    {
        throw new Exception();
    }
    if (!result)
    {
        throw new Exception();
    }
