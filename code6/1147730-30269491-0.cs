    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                List<string> myStr = new List<string>();
                List<int> roleIntList = new List<int>();
    
                roleIntList.Add(1);
                roleIntList.Add(2);
                roleIntList.Add(3);
                roleIntList.Add(4);
    
                foreach (var rolenodes in roleIntList)
                {
                    string ss = rolenodes.ToString();
                    myStr.Add(ss);
                }
    
                foreach (string s in myStr)
                {
                    Console.WriteLine(s);
                }
    
                Console.Read();
    
    
            }
        }
    }
