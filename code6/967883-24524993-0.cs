    .SelectList(list => list
        .Select(p => p.Active).WithAlias(() => dto.Active)
        .Select(p => p.Alert).WithAlias(() => dto.Alert)
        .Select(p => p.Comments).WithAlias(() => dto.Comments)
        // instead of this
        //.Select(p => string.Format("{0}api/Person/{1}", uriHelper.Root, p.Id))
        //       .WithAlias(() => dto.DetailsUrl)
        // use this
        .Select(p => Projections.Concat(uriHelper.Root, Projections.Concat, p.Id))
               .WithAlias(() => dto.DetailsUrl)
        )
        .TransformUsing(Transformers.AliasToBean<PersonResponseMessage>())
        .List<PersonResponseMessage>();
