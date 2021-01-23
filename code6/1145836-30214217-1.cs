    var decimals = new decimal[] { 1M, 2M, decimal.MaxValue, decimal.MinValue };
    DecimalSplitted[] asUints = new StructConverter { Decimals = decimals }.Splitted;
    // Works correctly
    var h = GCHandle.Alloc(asUints, GCHandleType.Pinned);
    // But here we don't need it :-)
    h.Free();
    for (int i = 0; i < asUints.Length; i++)
    {
        DecimalSplitted ds = new DecimalSplitted
        {
            UInt0 = asUints[i].UInt0,
            UInt1 = asUints[i].UInt1,
            UInt2 = asUints[i].UInt2,
            UInt3 = asUints[i].UInt3,
        };
        Console.WriteLine(new DecimalToUint { Splitted = ds }.Decimal);
    }
