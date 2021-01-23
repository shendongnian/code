    var child = new Child
    {
        Name = "foo",
        Parent = new Parent {Name = "bar"}
    };
    session.Save(child);
    session.Flush();
    session.Clear();
    var persistedChild = session.Get<Child>(child.ID);
