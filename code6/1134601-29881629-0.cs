    using System;
    using System.Diagnostics.Contracts;
    namespace Upperc {
      class Program {
        static void Main(string[] args) {
          var input = Console.ReadLine();
          Contract.Assert(input != null);
          Console.WriteLine(input.ToUpperInvariant());
        }
      }
    }
