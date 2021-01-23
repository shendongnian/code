            public static void Test()
            {
                //Here we are just creating simple lists
                List<string> strings = new List<string>();
                strings.Add("a");
                strings.Add("b");
                strings.Add("c");
    
                List<int> integers = new List<int>();
                integers.Add(1);
                integers.Add(2);
                integers.Add(3);
    
                //Creating complex classes ( not really )
                ComplexClass cc1 = new ComplexClass();
                cc1.CCString = "A test";
                cc1.CCInt = 2;
    
                ComplexClass cc2 = new ComplexClass();
                cc2.CCString = "Another test";
                cc2.CCInt = 6;
    
                //Creating a list of these too
                List<ComplexClass> complexClasses = new List<ComplexClass>();
                complexClasses.Add(cc1);
                complexClasses.Add(cc2);
    
                // NEW LIST
                List<double> doubles = new List<double>();
                doubles.Add(99.99);
                doubles.Add(100.12);
    
                List<IList> myLists = new List<IList> {integers, strings, complexClasses, doubles};
                Permutate("", myLists, 0);
    
                Console.ReadLine();
            }
    
            public static void Permutate(string s, List<IList> list, int i)
            {
                if (i == list.Count)
                {
                    Console.WriteLine(s);
                }
                else
                {
                    foreach (object obj in list[i])
                    {
                        Permutate(s + obj + " ", list, i + 1);
                    }
                }
            }
            
            //The "Complex class" again not that complex but an example of what im tring to achieve
            public class ComplexClass
            {
                public string CCString { get; set; }
                public int CCInt { get; set; }
    
                // Added override
                public override string ToString()
                {
                    return CCString + CCInt;
                }
            }
