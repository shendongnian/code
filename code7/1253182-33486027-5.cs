    public class A
    {
        [Description("Const Field")]
        public const string ConstField = "My Const";
    }
    class Program
    {
        static void Main(string[] args)
        {
            var foo = AttributeHelper.GetFieldAttributeValue<A, string, DescriptionAttribute, string>("ConstField", y => y.Description);
            Console.WriteLine(foo);
        }
    }
