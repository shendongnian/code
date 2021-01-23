     public class Animal
        {
            public string Colour { get; set; }
            public long Weight { get; set; }
            public string Name { get; set; }
            public Animal Create<T>(T anyType)
            {
                return GetObject<T, Animal>(anyType);
            }
            public K GetObject<T, K>(T type1)
            {
                try
                {
                    var serialized = JsonConvert.SerializeObject(type1);
                    return JsonConvert.DeserializeObject<K>(serialized);
                }
                catch (Exception ex)
                {
                    return default(K);
                }
            }
        }
        class Program
        {
            public static void Main(string[] args)
            {
                Animal obj = new Animal();
                var animal = obj.Create(new  { Colour = "Red", Weight = 100 });
                //here you can pass any object, only same name properties will be initialized..
                Console.WriteLine(animal.Colour + " :  " + animal.Weight);
                Console.ReadKey();
            }
        }
