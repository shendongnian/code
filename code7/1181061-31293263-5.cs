    public ClienteMap()
    {
        ...
        HasMany(x => x.ListaMedidores)
           //.KeyColumn("NUMERO_MEDIDOR")
           .KeyColumn("CORE_NUMERO_MEDIDOR") // column in other table
           .Inverse().Cascade.All();
    }
    public MedidorMap()
    {
        ...
        References(x => x.Cliente)
            .Column("CORE_NUMERO_MEDIDOR");  // column in this table
    }
