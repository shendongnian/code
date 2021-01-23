    public class Test
    {
        [Fact]
        public void TestIt()
        {
            var kernel = new StandardKernel();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            var foo = kernel.Get<Foo>();
            foo.DoStuffToRepositories(typeof(string), typeof(int));
        }
    }
