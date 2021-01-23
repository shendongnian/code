    public class T1
    {
        public T1():this(String.Empty) // <= calling constructor with parameter
        {
           Console.WriteLine("t1");
        }
        public T1(string s)
        {
           Console.WriteLine(s);
        }
    }
