    public interface IDatabase
    {
        DataSet ProvideCultureMappings(Guid userId, Culture culture);
    }
    public interface IBLLogger
    {
        Exception Log(Exception exception);
    }
    public interface IBLDataPopulation
    {
        IEnumerable<Culture> PopulateCultures(DataTable dataTable);
    }
