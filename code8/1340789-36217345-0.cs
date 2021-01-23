    using (var scope = session.OpenTransaction())
    {
        var message = new Message();
        .... // some code here
        session.Save(message);
        var addedSession = new AddedSession { Date = DateTime.Now };
        session.Save(addedSession);
        message.AddedSession = addedSession;
        scope.Commit();
    }
