    var Books = new List<Books>(2){
                new Books(),
                new Books()
            }.AsQueryable();
    var asycEnumarable = new TestDbAsyncEnumerable<Books>(Books);
    var viewStore = MockRepository.GenerateStub<IRepository<Books>>();
    viewStore.Stub(x => x.FindBy(Arg<Expression<Func<Books, bool>>>.Is.Anything))
             .Return(asycEnumarable);
