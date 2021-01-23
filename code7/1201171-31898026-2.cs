    public class Foo
    {
        public static int Boo=10;
      
        public void AddTen()
        {
          Boo += 10;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
          var f1 = new Foo();
          f1.AddTen();
          Console.WriteLine(Foo.Boo);// Output:20
        }
    }
