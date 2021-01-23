    namespace MyProject.Foo.Model
    {
        public interface IFoo
        {
            string Property1 { get; set; }
            string Property2 { get; set; }
        }
        public interface IFooRepository
        {
            IEnumerbale<IFoo> GetFoos();
        }
    }
