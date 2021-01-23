    public class SomeClass : ISomeClass
    {
        private readonly IResolver resolver;
        public SomeClass(IResolver resolver)
        {
            this.resolver = resolver;
        }
        public void SomeMethod(string whatever)
        {
            if (!resolver.ResolvesAll("fred", "barny", "wilma"))
               throw new Exception("missing dependencies");
            var fred = resolver.Resolve<string>("fred");
            SomeOtherMethod(fred, whatever);
        }
    }
