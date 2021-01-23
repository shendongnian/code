    public class BaseController : Controller
    {
        public T CreateBaseModel<T>() where T : BaseModel, new()
        {
            return new T
            {
                foo = "foo value",
                bar = "bar value"
            };
        }
    }
