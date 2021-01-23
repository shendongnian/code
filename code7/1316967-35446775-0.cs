    public class MyService<TModel, TMember>
    {
        public MyService(Expression<Func<TModel, TMember>> member)
        {
        }
    }
