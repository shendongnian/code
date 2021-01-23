    public SqlServerPersonRepository : IPersonRepository 
    {
        void Add(IPerson person)
        {
            //sql server specific code
        }
    }
    public SqlLitePersonRepository : IPersonRepository 
    {
        void Add(IPerson person)
        {
            //sqlite specific code
        }
    }
