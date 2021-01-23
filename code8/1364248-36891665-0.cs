    class KeyGenerator
    {
        private int _value = 0;
        public int NextId()
        {
            return --this._value;
        }
    }
    abstract class ModelBase
    {
        private KeyGenerator _generator;
        public ModelBase(KeyGenerator _generator)
        {
            this._generator = _generator;
        }
        public void SaveObject()
        {
            int id = this._generator.NextId();
            Console.WriteLine("Saving " + id.ToString());
        }
    }
    class Car : ModelBase
    {
        private static KeyGenerator carKeyGenerator = new KeyGenerator();
        public Car()
            : base(carKeyGenerator)
        {
        }
    }
    class Food : ModelBase
    {
        private static KeyGenerator foodKeyGenerator = new KeyGenerator();
        public Food()
            : base(foodKeyGenerator)
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Food food1 = new Food();
            Food food2 = new Food();
            Car car1 = new Car();
            food1.SaveObject();
            food2.SaveObject();
            car1.SaveObject();
        }
    }
