    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Bag> bags = new List<Bag>() {
                    new Bag() { containers = new List<Container>() {
                        new Container() { apples = new List<Apple>() {
                            new Apple() { weight = 1.0},
                            new Apple() { weight = 1.2},
                            new Apple() { weight = 1.3}
                        }},
                        new Container() { apples = new List<Apple>() {
                            new Apple() { weight = 0.9},
                            new Apple() { weight = 1.15}
                        }}
                    }},
                    new Bag() { containers = new List<Container>() {
                        new Container() { apples = new List<Apple>() {
                            new Apple() { weight = 1.0},
                            new Apple() { weight = 1.2},
                            new Apple() { weight = 1.3}
                        }},
                        new Container() { apples = new List<Apple>() {
                            new Apple() { weight = 0.9},
                            new Apple() { weight = 1.15}
                        }}
                    }}
                };
                double total = bags.Select(x => x.containers.Select(y => y.apples.Select(z => z.weight))).SelectMany(a => a).SelectMany(b => b).Sum();
            }
        }
        public class Bag
        {
            public List<Container> containers { get; set; }
        }
        public class Container
        {
            public List<Apple> apples { get; set; }
        }
        public class Apple
        {
            public double weight { get; set; }
        }
    }
