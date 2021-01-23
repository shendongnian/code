    public class Api<TApi, TModel> where TApi: Api<TApi, TModel> where TModel : Model
    {
        public List<TModel> CallGenericMethod()
        {
            return new List<TModel>();
        }
    }
    public class ApiB: Api<ApiB, ModelB> { }
    public static string DoSomething<TApi, TModel>(Api<TApi, TModel> a) where TApi : Api<TApi, TModel> where TModel: Model
    {
        return new Dictionary<TApi, TModel>().GetType().ToString();
    }
