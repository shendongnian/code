    public class T1
    {
        public T1()
        {
           Console.WriteLine("t1");
        }
        public T1(string s) : this()  // <= calling parameterless constructor 
        {
           Console.WriteLine(s);
        }
    }
