    public class NullableMap : ClassMap<Nullable>
    {
        public NullableMap()
        {
            Table("nullable");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            Map(x => x.SenderId, "SenderId").Nullable().Default(null);
        }
    }
