    public interface IHasName
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class Test1 : IHasName
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class Test2 : IHasName
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public List<T> FillFromDB<T>()
        where T : new(), IHasName
    {
       IQueryable<T> query =
          from tbl in _table
          select new T {Name=tbl.name, Surname=tbl.surname}
    }
