    BigInteger na, nb;
    if (!BigInteger.TryParse(a, out na)) {
        Console.WriteLine("A is invalid: '{0}'",a);
    }
    if (!BigInteger.TryParse(b, out nb)) {
        Console.WriteLine("B is invalid: '{0}'", b);
    }
    var nc = na + nb;
    return nc.ToString();
