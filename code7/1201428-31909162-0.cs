    using System.Collections.Generic;
    using System.Linq;
        private enum SortOrder
        {
            Rabbit,
            Wolf,
            Eagle
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                var animals = (new List<Animal> { new Wolf {Kills = 5},
                                         new Rabbit {Name = "Uncle John"},
                                         new Eagle {EyeCount = 1},
                                         new Wolf {Kills = 100},
                                         new Rabbit { Name = "Human" } })
                                .OrderBy(x => x.SortOrder)
                                .ThenBy(x => x.Classifier);
                //Suposted to be: Rabbit(Human), Rabbit(Uncle John), Wolf(5), Wolf(100), Eagle(1)
            }
        }
        private abstract class Animal
        {
            public abstract object Classifier { get; }
            public string Name { get; set; }
            public SortOrder SortOrder { get; set; }
        }
        private class Eagle : Animal
        {
            public Eagle()
            {
                this.SortOrder = SortOrder.Eagle;
            }
            public override object Classifier
            {
                get { return this.EyeCount; }
            }
            public byte EyeCount { get; set; }
        }
        private class Rabbit : Animal
        {
            public Rabbit()
            {
                this.Name = "Funny Little Guy";
                this.SortOrder = SortOrder.Rabbit;
            }
            public override object Classifier
            {
                get { return this.Name; }
            }
        }
        private class Wolf : Animal
        {
            public Wolf()
            {
                this.Name = "Funny Little Guy";
                this.SortOrder = SortOrder.Wolf;
            }
            public override object Classifier
            {
                get { return this.Kills; }
            }
            public int Kills { get; set; }
        }
