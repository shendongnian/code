    public interface IName
    {
        string Name { set; get; }
    }
    class A : IName {
        public string Name
    }
    class B : IName {
        public string Name
    }
    public static List<T> Filter<T>(this List<T> list, string search) where T : IName
    {
        return list.Where(t => t.Name.FormatSearch().Contains(search)).ToList();  
    }
