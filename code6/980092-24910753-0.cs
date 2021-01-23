    public class SomeClass<TModel> where TModel : class, IModel
    {
        SetControl(IControl<TModel> control)
        {
            IControl<IModel> c = control;
        }
    }
