    public abstract class TransformerAbstract
    {
        public virtual object transform(object entity);
    }
    
    public class CycleTransformer : TransformerAbstract
     {
        public new object transform(object entity)
        {
            throw new NotImplementedException();
        }
    }
