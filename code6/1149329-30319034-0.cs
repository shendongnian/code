     internal class Program
    {
        public class Animal
        {
            public string Name { get; set; }           
        }
        public class Cat : Animal
        {
            public int Age { get; set; }
            public string Type { get; set; }
        }
        public static void Main()
        {
            var cat = new Cat();
            cat.Name = "Puss";
            var animal = cat.ToBaseClass<Animal, Cat>();
            
            Debug.Assert(!(animal is Cat));
            Debug.Assert(animal.Name == "Puss");
        }
    }
    public static class ReflectionHelper
    {
        public static TBase ToBaseClass<TBase, TDerived>(this TDerived from) 
            where TBase : new()
            where TDerived : TBase
        {
            var result = new TBase();
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(result))
            {
                propertyDescriptor.SetValue(result, propertyDescriptor.GetValue(from));
            }
            return result;
        }
    }
