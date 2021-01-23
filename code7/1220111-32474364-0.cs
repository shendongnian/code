    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        static class MyExtensions
        {
            public static int toInt32(this string field)
            {
                return Convert.ToInt32(field);
            }
        }
        class MySpecificList
        {
            Dictionary<string, string> _fields = new Dictionary<string, string>();
            public string this[string name]
            {
                get
                {
                    return _fields[name];
                }
                set
                {
                    _fields[name] = value;
                }
            }
            static void Main(string[] args)
            {
                MySpecificList list = new MySpecificList();
                list["field1"] = "1";
                Console.WriteLine(list["field1"].toInt32() + 1);
            }
        }
    }
