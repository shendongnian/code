    Child childAlias = null;
    Parent parentAlias = null;
    int[] parentIds = new int[] {1, 2, 3};
    var temp = sess.QueryOver<Parent>()
        .JoinQueryOver(p => p.Children, () => childAlias)
        .WhereRestrictionOn(c => c.Parent.ID).IsIn(parentIds)
        .Select(Projections.ProjectionList()
            .Add(Projections.GroupProperty(Projections.Property<Parent>(x => x.ID)))
            .Add(Projections.Count(() => childAlias.ID)))
        .List<object[]>()
        .Select(x => new KeyValuePair<int,int>((int)x[0], (int)x[1]));
