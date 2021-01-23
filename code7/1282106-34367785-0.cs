    public interface IObjectiveQuery
    {
        DataRow ForList(int id);
        bool Contains(string someUniqueKey);
        IEnumerable<DataRow> Search(string descriptionLike, DateTime startDate);
        string Description(int id);
    }
    
