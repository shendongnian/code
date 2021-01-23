    Func<MyTable, MyTableDTO> selectExp=x => new MyTableDTO{
                                                             ID = x.ID,
                                                             Name = x.Name
                                                            });
    //Pass the lambda expression as a paremter
    public static IQueryable<MyTableDTO> ToDto(this IQueryable<MyTable> query, Func<MyTable, MyTableDTO> selectExpr)
    {
        return query.Select(selectExpr);
    }
