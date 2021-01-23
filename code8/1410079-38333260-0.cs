    [TestFixture]
    public class UnitTest3
    {
        public class Foo
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    
        private readonly IDocumentStore _documentStore;
    
        public UnitTest3()
        {
            _documentStore = new EmbeddableDocumentStore
            {
                Configuration =
                {
                    RunInUnreliableYetFastModeThatIsNotSuitableForProduction = true,
                    RunInMemory = true,
                }
            }.Initialize();
        }
    
        public void InsertDummies()
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                for (int i = 0; i < 1000; i++)
                {
                    Foo foo = new Foo { Name = "Foo" + i };
                    session.Store(foo);
                }
    
                Foo fooA = new Foo { Name = "MyName"};
                session.Store(fooA);
                Foo fooB = new Foo { Name = "MyName" };
                session.Store(fooB);
    
                session.SaveChanges();
            }
        }
    
        [Test]
        public void Query()
        {
            List<Foo> result;
            InsertDummies();
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                result = session.Query<Foo>().Where(f => f.Name.Equals("MyName")).ToList();
            }
            Assert.AreEqual(2, result.Count);
        }
    }
