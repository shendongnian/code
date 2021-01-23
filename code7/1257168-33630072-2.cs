    public IList<Child> GetChilds(IEnumerable<Parent> parents)
    {
        Parent parentAlias = null;
        this.Sessao.QueryOver<Wave>()
                .Inner.JoinAlias(x => x.Parent, () => parentAlias)
                .WhereRestrictionOn(() => parentAlias.Id).IsIn(parents.Select(x => x.Id).ToList())
    }
