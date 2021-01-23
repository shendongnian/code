    using System;
    using System.IO;
    
    class Test 
    {
    	
        public static void Main() 
        {
            string path = @"c:\temp\MyTest.txt";
            try 
            {
                using (StreamReader sr = new StreamReader(path)) 
                {
                    while (sr.Peek() >= 0) 
                    {
                        Console.WriteLine(sr.ReadLine());
    
                    }
                }
            } 
            catch (Exception e) 
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
