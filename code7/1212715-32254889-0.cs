    public IRepository<object> SetRepo(string TableName)
    {
        switch (TableName)
        {
            case "Line":
                return LineRepository;
                break;
        }
    }
