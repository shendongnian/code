    public abstract BaseTypeOfAB
    {
        public string template { get; set; }
    }
    public class A : BaseTypeOfAB
    {
        public int IntProp { get; set; }
    }
    public class B : BaseTypeOfAB
    {
        public string name { get; set; }
    }
    static List<T> filterByTemplate<T>(List<T> list, string skipInBList, char separator) where T : BaseTypeOfAB
    {
        foreach (string template in skipInBList.Split(separator))
            list.RemoveAll(x => x.template.Equals(template));
        return list;
    }
