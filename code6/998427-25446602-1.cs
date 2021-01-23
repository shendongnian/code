    // here we declare the DTO to be used for ALIASing
    ResultDTO dto = null;
    // here is our query
    var result = session.QueryOver<Table>()
        .SelectList(l => l
            .SelectGroup(x => x.Name).WithAlias(() => dto.Name)
            .SelectCount(x => x.Name).WithAlias(() => dto.Count)
        )
        .TransformUsing(Transformers.AliasToBean<ResultDTO>())
        .List<ResultDTO>();
