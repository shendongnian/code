    var Books= new List<Books>(2){
                new Books(),
                new Books()
            }.AsQueryable();
    mock.Expect(viewStore => viewStore.FindBy(Arg<Expression<Func<Books, bool>>>.Is.Anything))
        .Return(Books);
