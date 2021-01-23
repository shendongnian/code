    using System;
    using System.Collections.Generic;
    using System.Data.OracleClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          var cmd = new OracleCommand();
          cmd.Parameters.Add("param1", OracleType.DateTime);
          var value = cmd.Parameters["param1"];
          Console.WriteLine(value.Value == null ? "null" : value.Value.ToString());
        }
      }
    }
