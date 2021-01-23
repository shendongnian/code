    using System.IO;
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    class AnyClass {
        delegate void Del(string str);
        private static Dictionary < Del, string > dict = new Dictionary < Del, string > ();
        static void Main() {
            List < Del > listDel = new List < Del > ();
            listDel.Add(delegate(string str) {
                Console.WriteLine("Delegate 1");
            });
            Console.WriteLine(listDel[0].Method.ToString());
            listDel[0].Invoke("");
            dict.Add(listDel[0], "Delegate 1");
            listDel.Add(delegate(string str) {
                Console.WriteLine("Delegate 2");
            });
            Console.WriteLine(listDel[1].Method.ToString());
            listDel[1].Invoke("");
            dict.Add(listDel[1], "Delegate 2");
            for (int i = 0; i < 2; i++) {
                factory(listDel);
                listDel.Add(delegate(string str) {
                    Console.WriteLine("Delegate " + (2 + i) + " " + str);
                });
                dict.Add(listDel[i + 2], "Delegate " + (2 + i));
            }
            Console.WriteLine(listDel[2].Method.ToString());
            listDel[2].Invoke("2");
            Console.WriteLine(listDel[3].Method.ToString());
            listDel[3].Invoke("3");
            Console.WriteLine(listDel[2] == listDel[3]);
            Console.ReadLine();
        }
        private static void factory(List < Del > list) {
            list.Add(delegate(string str) {
                Console.WriteLine("Delegate " + str);
            });
        }
    }
