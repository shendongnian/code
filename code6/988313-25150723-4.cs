    using System;
    using System.Linq;
                        
    public class Program
    {
        public static void Main()
        {
            string text = "abc,xyz,pqr,linq,xyz,abc,is,xyz,pqr,fun";
                    
            var lookup =
                text.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select((str, idx) => new { str, idx })
                .ToLookup(x => x.str, x => (uint)x.idx);
            
            foreach (IGrouping<string, uint> itemGroup in lookup)
            {
                Console.WriteLine("Item '{0}' appears at:", itemGroup.Key);
                
                foreach (uint item in itemGroup)
                {
                    Console.WriteLine("- {0}", item);
                }
            }
        }
    }
