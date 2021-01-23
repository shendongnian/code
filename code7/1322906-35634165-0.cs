    IQueryable<MyObj> qry = MyDAL.GetObjs();
    if (someCond) {
        qry = qry.Where(p => p.SomeCond == someValue);
    }
    if (someOtherCond) {
        qry = qry.Where(p => someCollection.Contains(p.SomeValue));
    }
    return qry;
