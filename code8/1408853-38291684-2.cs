    public interface ISizable
    {
         ISetSizePorvider { get; }
    }
    public interface ISetSizeProvider
    {
         void SetSize(Size size);
    }
