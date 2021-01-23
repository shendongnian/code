    var types = new List<Type>
    {
        typeof(Smokey),
        typeof(Rasher),
        typeof(Danish)
    };
    var bacon = new List<Bacon>();
    // ..
    var selectedBacon = new List<Bacon>();
    if (types.Count != 0)
    {
        // We clone it
        var types2 = types.ToList();
        foreach (var b in bacon)
        {
            var btype = b.GetType();
            // A bacon could be of multiple "types" thanks to subclassing
            while (true)
            {
                // The IsAssignableFrom is equivalent to the is operator
                int ix = types.FindIndex(x => x.IsAssignableFrom(btype));
                if (ix != -1)
                {
                    selectedBacon.Add(b);
                    types2.RemoveAt(ix);
                }
                else
                {
                    break;
                }
            }
            if (types2.Count == 0)
            {
                break;
            }
        }
    }
