    protected void Application_Start()
    {
        Start(() =>
        {
            using (EF.DMEntities context = new EF.DMEntities())
            {
                context.DMUsers.FirstOrDefault();
            }
        });
    }
    private void Start(Action a)
    {
        a.BeginInvoke(null, null);
    } 
