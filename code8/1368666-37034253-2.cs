    public interface IBase
    {
        object Id{ get; set; }
        string Name{ get; set; }
    }
    
    public interface IType1 : IBase{}
    public interface IType2 : IBase{}
    
    public static T GetObjectByIdOrName<T>(this IEnumerable<T> collection, Mapping mapping) where T : IBase
    {
        //... get T.Id or T.Name
    }
