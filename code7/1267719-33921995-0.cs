    long x = 8223372036854775807; // arbitrary long number
    double y = x; // implicit conversion to double
    long z = Convert.ToInt64(y); // convert back to int64 (a.k.a. long)
    System.Diagnostics.Debug.Print(x.ToString());
    System.Diagnostics.Debug.Print(z.ToString());
