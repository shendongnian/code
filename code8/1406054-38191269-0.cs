    public class ConfigurationObjectBase<ObjectType>
    {
        public ConfigurationObjectBase(ConfigurationObjectManagerBase<ObjectType> ownerManager)
        {
            ownerManager.ChildObjects.Add(this);
        }
    }
    
    
    public class ConfigurationObjectManagerBase<ObjectType>
    {
        public ConfigurationObjectManagerBase()
        {
            ChildObjects = new List<ConfigurationObjectBase<ObjectType>>();
        }
    
        public List<ConfigurationObjectBase<ObjectType>> ChildObjects { get; set; }
    }
    
    public class Catalog : ConfigurationObjectBase<Catalog>
    {
        public Catalog(CatalogManager ownerManager) : base(ownerManager)
        {
    
        }
    }
    
    public class CatalogManager : ConfigurationObjectManagerBase<Catalog>
    {
        public CatalogManager()
        {
        }
    }
