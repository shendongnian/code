    _moqSet.As<IQueryable<Models.Campaign>>()
    .Setup(m => m.Include(It.IsAny<Expression<Func<Models.Campaign, object>>>()))
    .Returns((Expression<Func<Models.Campaign, object>> predicate) =>
    {
        return _moqSet.Object.Include(predicate);
    });
