    public void Connect()
    {
        Action action = Connect;
        Program.Container.Resolve<ITaskWrapper>(new NamedParameter("action", action));
    }
