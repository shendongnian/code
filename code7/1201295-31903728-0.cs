    public static class MyExtensions
    {
        public static ApiContext DeepClone(this ApiContext context)
        {
            ApiContext other = (ApiContext)context.MemberwiseClone();
            return other;
        }
    } 
  
