    public interface IRequest
    {
        string GetValue();
        BaseResult Apply<T>() where T : BaseResult;
    }
    public class MyRequest : IRequest
    {
        public BaseResult Apply<T>() where T : BaseResult
        {
            return new Result();
        }
        public string GetValue() { return string.Empty; }
    }
