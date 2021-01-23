     public class myClass
        {
            public myClass(string text, int num)
            {
                this.Text = text;
                this.Num = num;
            }
    
            public string Text { get; set; }
            public int Num { get; set; }
        }
    
        public class MyObj { }
    
        public class AlwaysTrueHashSet<T> : HashSet<T>
        {
            public override bool Equals(object obj)
            {
                return this.GetHashCode() == obj.GetHashCode();
            }
    
            public override int GetHashCode()
            {
                return "Counting hashcode".GetHashCode();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                 
    
                Dictionary<HashSet<myClass>, List<MyObj>> myDict = new Dictionary<HashSet<myClass>,
    
    
                List<MyObj>>();
                var myHashSet1 = new AlwaysTrueHashSet<myClass>();
                myHashSet1.Add(new myClass("123", 5));
                myDict.Add(myHashSet1, null);
    
    
    
                var myHashSet2 = new AlwaysTrueHashSet<myClass>();
                myHashSet2.Add(new myClass("123", 5));
    
                /*
                 * when containsKey is invoked, it's checking if the reference of myHashSet2 is the same as myHashSet1.
                 * That's the default behavior.
                 * 
                 * extend HashSet, and override the gethashcode and equal methods  
                 */
                if (myDict.ContainsKey(myHashSet2))
                {
                    Console.WriteLine("in");
                    int i = 3; // it doesn't get this line }  
                }
            }
        }
