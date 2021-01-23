    using System.IO;
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    
    class AnyClass
    {
        delegate void Del(string str);
    
        private static Dictionary<Del, string> dict = new Dictionary<Del, string>();
        static void Main()
        {
            List<Del> listDel = new List<Del>();
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                listDel.Add(factory());
                dict.Add(listDel[i ], "Delegate " + (i));
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(listDel[i].Method.ToString());
                listDel[i].Invoke((i).ToString());
            }
    
            Console.ReadLine();
        }
    
        public class DelegateEncapsulator
        {
            public void myMethod(string str) { Console.WriteLine("Delegate " + str); }
        }
    
        private static Del factory()
        {
            var obj = new DelegateEncapsulator();
            var ret = (Del)Delegate.CreateDelegate(typeof(Del), obj, typeof(DelegateEncapsulator).GetMethod("myMethod"));
            return ret;
        }
    }
