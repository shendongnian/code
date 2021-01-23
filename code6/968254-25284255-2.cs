    public MyRepository(MyObjectContext context, String userName = null)
    {
        this.context = context;
        if (!configuration.HardDelete)
        {
            this.context.EnableFilter("SoftDelete");
        }
    }
