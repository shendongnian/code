    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication2
    {
        class Test
        {
            public int Value { get; set; }
            public string NiceString { get; set; }
        }
        class Wrapper<T>
        {
            public T Item;
            public Wrapper(T item)
            {
                Item = item;
            }
            public static implicit operator Wrapper<T>(T item)
            {
                return new Wrapper<T>(item);    
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var testList = new List<Wrapper<Test>>
                {
                    new Test {Value = 1, NiceString = "First"},
                    new Test {Value = 2, NiceString = "Second"},
                    new Test {Value = 3, NiceString = "Third"}
                };
                var replacementTestClass = new Test { Value = 2, NiceString = "NEW" };
                EasyWay(testList, replacementTestClass);
                var correctTestClass = testList.FirstOrDefault(x => x.Item.Value == 2);
                Console.WriteLine(correctTestClass.Item.NiceString); //Expecting "New"
                Console.ReadLine();
            }
            private static void EasyWay(List<Wrapper<Test>> testList, Test replacementTestClass)
            {
                var secondTestClass = testList.FirstOrDefault(x => x.Item.Value == 2);
                secondTestClass.Item = replacementTestClass;
            }
        }
    }
