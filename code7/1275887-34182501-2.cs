    public abstract class BaseTypeOfAB
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
    static List<T> filterByTemplate<T>(List<T> list, string skipInList, char separator) where T : BaseTypeOfAB
    {
        foreach (string template in skipInList.Split(separator))
            list.RemoveAll(x => x.template.Equals(template));
        return list;
    }
