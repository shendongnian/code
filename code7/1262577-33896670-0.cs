    session.QueryOver<Transaction>(() => transaction).
    SelectList(list => list.
        SelectSubQuery(QueryOver.Of<Customer>().Where(c => c.ID == transaction.ID).Select(c => c.Name)).
        SelectGroup(() => transaction.CustomerId).
        SelectMin(() => transaction.Date)
    ).
    .OrderBy(Projections.Min<Transaction>(trans => trans.Date)).Asc.
    List<object[]>().
    ToList();
