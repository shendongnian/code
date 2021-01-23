    using (var context = new SampleContext())
    {
        // add some entities
        context.People.Add(new Person { Id = 100, Name = "John" });
        // remove some
        context.People.Remove(context.People.Find(1));
        var memento = new SampleContextMemento(context);
        context.SaveChanges();
        memento.Rollback();
    }
