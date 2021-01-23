    foreach(var c in Customer)
    {
        var caToClear = c.CustomerAddress().ToList();
        c.CustomerAddress.RemoveAll();
        foreach(var ca in c.caToClear)
        {
            ca.Delete();
        }
    
        var cpToClear = c.CustomerProducts.ToList();
        c.CustomerProducts.RemoveAll();
        foreach(var cp in cpToClear)
        {
            var poToClear = cp.ProductOrdered.ToList();
            cp.ProductOrdered.RemoveAll();
            foreach(var po in poToClear)
            {
                po.Delete();
            }
            cp.Delete();
        }
        c.Delete();
    }
