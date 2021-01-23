        public class CycleTransformer : TransformerAbstract
        {
            public override object Transform(object entity)
            {
                if (entity is CycleData)
                {
                    // Do transform
                }
                else if (entity is FireData)
                {
                    // Do transform
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
