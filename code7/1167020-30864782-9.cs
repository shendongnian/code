    namespace System.Collections.Generic
    {
      extern alias mscorlib;
      public class List<T>
      {
        public string Count
        {
          get{ return "This is a very strange “Count”, isn’t it?"; }
        }
      }
      class Program
      {
        public static void Main(string[] args)
        {
          var myList = new System.Collections.Generic.List<int>();
          var theirList = new mscorlib::System.Collections.Generic.List<int>();
          Console.WriteLine(myList.Count);
          Console.WriteLine(theirList.Count);
          Console.Read();
        }
      }
    }
