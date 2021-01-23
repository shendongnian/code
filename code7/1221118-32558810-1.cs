    [IntroduceMember(Visibility = Visibility.Family, OverrideAction = MemberOverrideAction.Ignore)]
    [CopyCustomAttributes(typeof (ImportAttribute))]
    [Import(typeof(ISession))]
    public ISession Session
    {
      get
      {
        if(session == null || !session.IsOpen)
        {
           session = sessionFactory.OpenSession();
        }
       return session;
      }
    }
