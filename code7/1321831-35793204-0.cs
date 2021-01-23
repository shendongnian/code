    public partial class LogicFactory : IPexClassFactory<Logic>
    {
        public Logic Create()
        {
            //...
        }
    }
    [assembly: PexCreatableByClassFactory(typeof(Logic), typeof(LogicFactory))]
