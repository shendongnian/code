    double[] lattice = { 2.3, 2.8, 4.1, 4.7 };
    double[] values = { 2.35, 2.4, 2.6, 3, 3.8, 4.5, 5.0, 8.1 };
    var result = new List<double>[lattice.Length];  // array of lists
    for (int l = lattice.Length - 1, v = values.Length - 1; l >= 0; l--) // starts from last elements
    {
        result[l] = new List<double>(values.Length / lattice.Length * 2); // optional initial capacity of the list
                        
        for (; v >= 0 && values[v] >= lattice[l]; v--)
        {
            result[l].Insert(0, values[v]);
        }
    }
