    public enum ResourceType
    {
        Plant,
        Rock,
        Block
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited=false)]
    public class ResourceDeclAttribute : Attribute
    {
        public ResourceDeclAttribute( ResourceType resType )
        {
            this.ResType = resType;
        }
        public ResourceType ResType { get; private set; }
    }
    public class Resource 
    {
        // ...
    }
    [ResourceDecl( ResourceType.Plant )]
    public class Plant { 
        // ...
    }
    [ResourceDecl( ResourceType.Block )]
    public class Block
    {
    }
    public class Loader
    {
        private Dictionary<ResourceType, Type> enumToTypeMap;
        public Loader()
        {
            this.enumToTypeMap = new Dictionary<ResourceType, Type>();
        }
        public void Initialize()
        {
            Assembly targetAssembly;
            // Fill in with the right way to identify your assembly. One trick is to have a dummy
            // class in the assemblies that define your types, make a hard reference to those
            // classes, and then use the class's types to find out what assembly they came from.
            targetAssembly = Assembly.GetExecutingAssembly();
            Type[] exportedTypes = targetAssembly.GetExportedTypes();
            
            foreach( Type candidate in exportedTypes )
            {
                ResourceDeclAttribute attrib = candidate.GetCustomAttribute<ResourceDeclAttribute>();
                if( attrib != null )
                {
                    this.enumToTypeMap.Add( attrib.ResType, candidate );
                }
            }
        }
        public Resource Activate( ResourceType resType )
        {
            Type res = this.enumToTypeMap[resType];
            return (Resource)Activator.CreateInstance( res );
        }
    }
