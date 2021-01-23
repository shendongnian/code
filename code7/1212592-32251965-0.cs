    public class Circle
    {
        private readonly int Radius;
        public static int MyValue()
        {
            Console.WriteLine("Please enter radius value: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public Circle()
        {
            Radius = MyValue();
        }
    ...
    }
