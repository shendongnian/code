    // a new partial class extending the Foo generated class, allowing us to apply an interface
    public partial class Foo : IFooMetaData
    {
    }
    
    // meta data interface, forcing json ignore on Foo.Bars
    public interface IFooMetaData
    {
        [JsonIgnore]
        ICollection<Bar> Bars {get;set;}
    }
