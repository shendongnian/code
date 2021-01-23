    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    namespace SerializationDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dog dog = new Dog()
                {
                    Name = "Woofy",
                    HadWalkToday = true
                };
                Cat cat = new Cat()
                {
                    Name = "Fluffy",
                    ColorOfWhiskers = "Brown"
                };
                IList<Animal> animals = new List<Animal>()
                {
                    dog,
                    cat
                };
                string json = Serializer.Serialize(animals);
                IList<Animal> result = Serializer.Deserialize<List<Animal>>(json);
                bool serializerSuccessful = dog.Equals(result[0]) && cat.Equals(result[1]);
            }
        }
        public class Animal
        {
            public string Name { get; set; }
            public override bool Equals(object obj)
            {
                var animal = obj as Animal;
                return this.Name == animal.Name;
            }
        }
        public class Dog : Animal
        {
            public bool HadWalkToday { get; set; }
            public override bool Equals(object obj)
            {
                var dog = obj as Dog;
                return this.HadWalkToday == dog.HadWalkToday && base.Equals(obj);
            }
        }
        public class Cat : Animal
        {
            public string ColorOfWhiskers { get; set; }
            public override bool Equals(object obj)
            {
                var cat = obj as Cat;
                return this.ColorOfWhiskers == cat.ColorOfWhiskers && base.Equals(obj);
            }
        }
        public static class Serializer
        {
            private static readonly JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            };
            public static string Serialize(object obj)
            {
                if (obj == null)
                {
                    throw new NullReferenceException();
                }
                string jsonString = JsonConvert.SerializeObject(obj, settings);
                return jsonString;
            }
            public static T Deserialize<T>(string jsonString)
            {
                T obj = JsonConvert.DeserializeObject<T>(jsonString, settings);
                return obj;
            }
        }
    }
