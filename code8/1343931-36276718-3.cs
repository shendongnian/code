    var attrs = new HashSet<ProductAttribute>;
    attrs.Add(Color.Blue);
    attrs.Add(Color.Green);
    attrs.Add(Color.Blue); // no problem
    attrs.Add(Color.GetColor("blue")); // no problem
    attrs.Add(Size.Small);
    attrs.Add(Size.Medium);
    attrs.Add(Size.Medium); // no problem
