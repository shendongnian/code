    model.Manufacturers =
        PagedData.Products.SelectMany(p => p.Manufacturers
                                            .Select(t => new Manufacturer
                                                             {
                                                                 ManufacturerID = t.ManufacturerID,
                                                                 ManufacturerName = t.ManufacturerName})
                                            .AsEnumerable());
