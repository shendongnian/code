    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json.Linq;
    
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pattern = "[0-9]{2}-[0-9]{4}-[0-9]{2}";
                var input = "10-1283-01";
    
                var matches = Regex.Matches(input, pattern);
                if(Regex.IsMatch(input, pattern))
                {
                    Console.WriteLine("MATCH");
                }
    
    
    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    
    
    
    
    }
