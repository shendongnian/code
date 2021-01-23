    public abstract class ViewModel<TModel>
    {
        public class HtmlHelper : HtmlHelper<ViewModel<TModel>> {}
        public TModel Model;
    }
