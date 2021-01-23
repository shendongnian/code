    namespace SpecialFactory
    {
        class Program
        {
            static void Main(string[] args)
            {
                var m1 = new Manager();
                var m2 = new Manager();
                var i1 = m1.Test(ItemType.Item1);
                var i2 = m2.Test(ItemType.Item2);
            }
        }
    }
