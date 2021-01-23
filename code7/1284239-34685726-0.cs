    public class AssetTypeMap : ClassMapping<AssetType>
        {
            public AssetTypeMap()
            {
                ...
                Table("AssetType");
                ...
                Property(x => x.Type, x => {x.NotNullable(true); x.Type(NHibernateUtil.String);});
               ...
            }
        }
