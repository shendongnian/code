    ProductMap
    {
      HasManyToMany(x => x.Bundles).Table("BundleProduct").ParentKeyColumn("ProductId").ChildKeyColumn("BundleId").Cascade.None().Inverse().Not.LazyLoad();
    }
    BundleMap
    {
       HasManyToMany(x => x.Products)
                    .Table("BundleProduct")
                    .ParentKeyColumn("BundleId")
                    .ChildKeyColumn("ProductId")
                    .Cascade.All();
    }
