    public static class LinqExtensions
    {
        public static IEnumerable<T> Flatten<T>(this T source, Func<T, IEnumerable<T>> selector)
        {
            return selector(source).SelectMany(c => Flatten(c, selector))
                                   .Concat(new[] { source });
        }
    }
    //...    
    var catalogs = new Catalog[] 
    {
        new Catalog(1, 0, "CatalogA"),
        new Catalog(2, 1, "Catalogb"),
        new Catalog(3, 1, "CatalogC"),
        new Catalog(4, 2, "CatalogD"),
        new Catalog(5, 4, "CatalogE")
    };
    var models = new Model[]
    {
        new Model(5, "ItemA"),
        new Model(5, "ItemB"),
        new Model(4, "ItemA"),
        new Model(4, "ItemC"),
        new Model(2, "ItemA"),
        new Model(2, "ItemC"),
        new Model(1, "ItemD")
    };
    var catalogE = catalogs.SingleOrDefault(catalog => catalog.CatalogName == "CatalogE");
    var flattenedHierarchyOfCatalogE = catalogE.Flatten((source) =>
        catalogs.Where(catalog => 
            catalog.CatalogId == source.ParentCatalogId));
