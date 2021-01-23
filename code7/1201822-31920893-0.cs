    using(ISession session = dal.GetSession())
    {
    using (session.BeginTransaction())
    {
        Topic t = session.Get<Topic>(topicId);
        Category c = new Category() { Name=name };
        t.AddCategory(c);
        c.Topic = t;
        session.SaveOrUpdate(t);
        session.Transaction.Commit();
    }
    }
