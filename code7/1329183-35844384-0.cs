    using System;
    using System.Collections.Generic;
    using System.Reflection;
    
    public class Program
    {
        private static Dictionary<string, object[]> ValuesFor = new Dictionary<string, object[]>()
        {
            { typeof(int).ToString(), new object[] { 0, 1, 2, 3, 4, 5 } },
            { typeof(bool).ToString(), new object[] { true, false } }
        };
    
    
    
        public static void Main()
        {
            var properties = typeof(A).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            int[] valueIndices = new int[properties.Length];
    
            do
            {
                createObject(properties, valueIndices);
            } while (setNext(properties, valueIndices));
    
            Console.ReadKey();
        }
    
        /// <summary>
        /// This updates the valueIndex array to the next value
        /// </summary>
        /// <returns>returns true if the valueIndex array has been updated</returns>
        public static bool setNext(PropertyInfo[] properties, int[] valueIndices)
        {
            for (var i = 0; i < properties.Length; i++)
            {
                if (valueIndices[i] < ValuesFor[properties[i].PropertyType.ToString()].Length - 1) {
                    valueIndices[i]++;
                    for (var j = 0; j < i; j++)
                        valueIndices[j] = 0;
                    return true;
                }
            }
            return false;
        }
    
        /// <summary>
        /// Creates the object
        /// </summary>
        public static void createObject(PropertyInfo[] properties, int[] valueIndices)
        {
            var a = new A();
            for (var i = 0; i < properties.Length; i++)
            {
                properties[i].SetValue(a, ValuesFor[properties[i].PropertyType.ToString()][valueIndices[i]]);
            }
    
            print(a, properties);
        }
    
    
    
        public static void print(object a, PropertyInfo[] properties)
        {
            Console.Write("Created : ");
            for (var i = 0; i < properties.Length; i++)
                Console.Write(properties[i].Name + "=" + properties[i].GetValue(a) + " ");
            Console.Write("\n");
        }
    
    
    
        public class A
        {
            public int value { get; set; }
            public bool foo { get; set; }
            public bool bar { get; set; }
            public bool boo { get; set; }
        }
    }
