    public class A
    {
        [Description("Const Field")]
        public const string ConstField = "My Const";
    }
    class Program
    {
        static void Main(string[] args)
        {
            var foo = AttributeHelper.GetConstFieldAttributeValue<A, string, DescriptionAttribute>("ConstField", y => y.Description);
            Console.WriteLine(foo);
        }
    }
