    public class ModelFixVisitor
    {
        public ModelBase Visit(ModelBase model)
        {
            var asModel1 = model as MyModel1;
            if (asModel1 != null)
            {
                return new Model1FixVisitor().Visit(asModel1);
            }
            var asModel2 = model as MyModel2;
            if (asModel2 != null)
            {
                return new Model2FixVisitor().Visit(asModel2);
            }
            throw new NotImplementedException("Unknown model type.");
        }
    }
