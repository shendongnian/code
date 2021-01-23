    var query = db.Materials
        .Select(i => new Material
        {
            Brand = i.Brand,
            Category = i.Category,
            Language = i.Language,
            Bco = i.Bco,
            MaterialCod = i.MaterialCod,
            Derivation = i.Derivation,
            Artwork = i.Artwork,
            BcoDelivery = i.BcoDelivery,
            MaterialId = i.MaterialId
         });
    if (brand_name != null)
        query = query.Where(p => p.Brand.ToLower().Contains(brand_name.ToLower());
    if (category_name!= null)
        query = query.Where(p => p.Category.ToLower().Contains(category_name.ToLower());
    if (language_name!= null)
        query = query.Where(p => p.Language.ToLower().Contains(language_name.ToLower());
    IPagedList<Material> onePageOfProducts = query
        .OrderBy(i => i.MaterialCod)
        .ToPagedList<Material>(pageNumber, defaultPageSize);
