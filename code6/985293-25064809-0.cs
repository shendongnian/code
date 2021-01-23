    public abstract class abstractA
        {
            public abstract string  TestDictionary { get; set; }
            public abstract string TestListDictionary { get; set; }
           // public abstract string returnDictionary();
            public void   DoWork()
            {
                Console.WriteLine(this.TestDictionary);
                // do anything with the properties         
            }
        }
    
        public class classA : abstractA
        {
            public override string TestDictionary { get; set; }
            public override string TestListDictionary { get; set; }
            public classA(string a, string b )
            {
                this.TestDictionary = a;
                this.TestDictionary = b; 
            }
           
        }
