    public class DynamicJsonAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new DynamicJsonBinder(MatchName);
        }
     
        public bool MatchName { get; set; }
    }
