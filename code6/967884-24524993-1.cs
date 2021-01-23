    .SelectList(list => list
        .Select(p => p.Active).WithAlias(() => dto.Active)
        .Select(p => p.Alert).WithAlias(() => dto.Alert)
        .Select(p => p.Comments).WithAlias(() => dto.Comments)
        // just the ID
        .Select(p => p.Id).WithAlias(() => dto.Id)
        )
        .TransformUsing(Transformers.AliasToBean<PersonResponseMessage>())
        .List<PersonResponseMessage>()
        // do the concat here, once the data are transformed and in memory
        .Select(result => 
        {
            result.DetailsUrl = string.Format("{0}api/Person/{1}", uriHelper.Root, p.Id)
            return result;
        });
