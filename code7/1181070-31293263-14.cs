    public ClienteMap()
    {
        ...
        Map(x => x.NumeroMedidor).Column("CORE_NUMERO_MEDIDOR");
        HasMany(x => x.ListaMedidores)
            .Component(com =>
            {
                com.Parent(y => y.Cliente, "MARCA_MEDIDOR");
                com.Map(y => y.MarcaMedidor, "MARCA_MEDIDOR");
            })
            .PropertyRef("NumeroMedidor")
            .Table("MEDIDOR")
           // .Inverse() // NO INVERSE, won't work
           .Cascade.All();
    }
