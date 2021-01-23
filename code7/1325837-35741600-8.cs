    var memento = new SampleContextMemento();
    // make changes
    using (var context = new SampleContext())
    {
        // add some entities
        context.People.Add(new Person { Id = 100, Name = "John" });
        // remove some
        context.People.Remove(context.People.Find(1));
        // saving changes in our memento to rollback them later
        memento.RecordChanges(context);
        context.SaveChanges();
    }
    // rollback them
    using (var context = new SampleContext())
    {
        memento.RollbackChanges(context);
    }
