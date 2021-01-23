        public interface IA
    {
        string Name { get; set; }
    }
    public class A : IA
    {
        public string Name { get; set; }
    }
    public class B : A, IA
    {
        public new string Name
        {
            get { return base.Name; }
            set { base.Name = value + " set in B"; }
        }
    }
    public static class Test
    {
        public static void SetAndPrintName<T>(T value, string name) where T : IA
        {
            value.Name = name;
            Console.WriteLine(value.Name);
        }
    }
