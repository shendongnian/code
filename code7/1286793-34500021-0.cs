    using System.Collections.Generic;
    using System.Linq;
    namespace Example
    {
      class Program
      {
        static void Main(string[] args)
        {
            List<char> data =  "1234567890".ToList();
            //This does not remove all the element!!!
            for (int i = 0; i < data.Count; i++)
                data.RemoveAt(i);
        }
      }
    }
