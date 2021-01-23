    public class ComplexAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new MyComplexBinder();
        }
    }
