    [JsonConverter(typeof(PolymorphicAssemblyRootConverter), typeof(ABase))]
    public class ABase
    {
    }
    
    public class ADerived : ABase
    {
        public AInner[] DifferentObjects { get; set;}
    }
    public class AInner
    {
    }
    public class AInnerDerived : AInner
    {
    }
    ...
    public class PolymorphicAssemblyRootConverter: JsonConverter
    {
        public PolymorphicAssemblyRootConverter(Type classType) :
           this(new Assembly[]{classType.Assembly})
        {
        }
        // Here comes the rest of PolymorphicAssemblyRootConverter
    }
     
