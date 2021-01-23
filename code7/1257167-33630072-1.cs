    public IList<Child> GetChilds(IEnumerable<Parent> parents)
    {
        return this.Sessao.Query<Child>()
                          .Where(x => parents.Select(x => x.Id).ToList().Contains(x.Parent.Id))
                          .List();
    }
