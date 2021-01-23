    public class ClienteMap: ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Table("CLIENTE");
            Id(x => x.ClienteId, "CORE_ID");
            Map(x => x.NumeroMedidor).Column("CORE_NUMERO_MEDIDOR");
            HasMany(x => x.ListaMedidores)
                .KeyColumn("NUMERO_MEDIDOR")
                .Component(com =>
                {
                    com.ParentReference(y => y.Cliente);
                    com.Map(y => y.MarcaMedidor, "MARCA_MEDIDOR");
                })
                .PropertyRef("NumeroMedidor")
                .Table("MEDIDOR")
                // .Inverse() // NO INVERSE, won't work
                .Cascade.All();
        }
    }
