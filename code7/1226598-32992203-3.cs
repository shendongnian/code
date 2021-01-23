    using FluentNHibernate.Mapping;
    
    public class ItemMap : ClassMap<Item>
    {
        public ItemMap()
        {
            Table("Items");
            
            Map(item => item.DynamicProperties)
                .CustomType<StoreDynamicProperties>()
                .Column("Properties")
                .CustomSqlType("varchar(8000)")
                .Length(8000);
            ...
        }
    }
        
