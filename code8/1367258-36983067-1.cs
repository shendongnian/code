	public class MyLinqToHqlGeneratorsRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        public MyLinqToHqlGeneratorsRegistry()
            : base()
        {
            this.Merge(new ConvertToInt64HqlGenerator());
        }
    }
