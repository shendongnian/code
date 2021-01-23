    public class YourLinqToHqlGeneratorsRegistry:
        NHibernate.Linq.Functions.DefaultLinqToHqlGeneratorsRegistry
    {
        public YourLinqToHqlGeneratorsRegistry():base()
        {
            RegisterGenerator(
                NHibernate.Linq.ReflectionHelper.GetMethod(
                    () => YourLinqExtensions.Class(null)),
                new ClassGenerator());
        }
    }
