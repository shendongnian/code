    public class clsA : IYourInterface
    {
        ...
    }
    public interface IYourInterface
    {
        string strMessage { get; }
        bool cantAccessThisFn(string str);
    }
