    var parent = new Parent
    {
        Name = "foo",
        Children = new List<Child>
        {
            new Child {Name = "bar"},
            new Child {Name = "baz"},
        },
    };
    foreach (var ch in parent.Children)
    {
        ch.Parent = parent; // we MUST do this, there is .Inverse()
    }
    session.Save(parent);
    session.Flush();
    session.Clear();
    var persistedParent = session.Get<Parent>(parent.ID);
  
