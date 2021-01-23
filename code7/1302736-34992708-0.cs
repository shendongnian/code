    public interface IFluentProcessor1
    {
        IFluentProcessor2 ConnectionName(string connectionName);
    }
    public interface IFluentProcessor2
    {
        IFluentProcessor3 FilterClause(string whereClause);
    }
    public interface IFluentProcessor3
    {
        bool Execute(out string errorMessage);
    }
