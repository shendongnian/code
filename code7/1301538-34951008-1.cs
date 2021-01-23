    using System.Collections.Generic;
    using System.Linq;
    namespace TestField
    {
       class Program
      {
        private static void Main(string[] args)
        {
          var a = new List<A>();
          var b = new List<B>();
          a.Filter("string");
          b.Filter("string");
 
         }
      }
      public static class Extensions
      {
        public static List<T> Filter<T>(this IEnumerable<T> list, string search)
        where T : IName 
        => list.Where(t => t.Name.Contains(search)).ToList();
      }
      public interface IName
      {
        string Name { get; set; }
      }
      public class A : IName
      {
        public string Name { get; set; }
      }
     public class B : IName
     {
        public string Name { get; set; }
     }
    }
