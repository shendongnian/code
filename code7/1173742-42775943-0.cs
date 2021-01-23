    private IApplicationContext context;
     
    public void InitContext()
    {
       // Configure Spring programmatically
       var ctx = new CodeConfigApplicationContext();
       ctx.ScanWithAssemblyFilter(a => a.FullName.StartsWith("My.Assemble.Name.Path"));
       ctx.Refresh();
       context = ctx;
    }
