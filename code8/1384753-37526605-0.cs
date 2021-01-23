    $Source = @” 
    using System;
    namespace Scripts
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Console.Out.WriteLine("This is the miracle");
            }
        }
    }
    “@ 
    
    Add-Type $Source -Language CSharp  
    
    [Scripts.Program]::Main((""))
