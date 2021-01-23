    public ClienteMap()
    {
        ...
        References(x => x.Medidor, "CORE_NUMERO_MEDIDOR");
    }
    public MedidorMap()
    {
        ...
        Id(x => x.NumeroMedidor).Column("NUMERO_MEDIDOR")
                                   // column in this table to be compared
        HasMany(x => x.Clientes)
           .KeyColumn("CORE_NUMERO_MEDIDOR") // with column in other table
           .Inverse().Cascade.All();
    }
