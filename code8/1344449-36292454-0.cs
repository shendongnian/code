    public interface ITable<out T> where T : IRow
    {
        IEnumerable<T> DataRows { get; }
        int Id { get; set; }
        string Name { get; set; }
    }
