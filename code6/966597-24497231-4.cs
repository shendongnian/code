    public interface IProductComponent
    {
        string Name { get; set; }
        IEnumerable<IProductComponent> ChildComponents { get; }
        IEnumerable<IProductComponent> WalkAllComponents { get; }
        TProductComponent UniqueProductComponent<TProductComponent>() where TProductComponent : class, IProductComponent;
    }
    public interface ITelephone : IProductComponent
    {
        IGps Gps { get; }
    }
    public interface IMp3Player : IProductComponent
    {
    }
    public interface IGps : IProductComponent
    {
        double AltitudeAccuracy { get; }
    }
    public interface ISmartPhone : IProductComponent
    {
        ITelephone Telephone { get; }
        IMp3Player Mp3Player { get; }
    }
