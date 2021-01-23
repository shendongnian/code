           Stopwatch sw = new Stopwatch();
            var s = @"public class Example 
                    {
                       public string Name { get; set; }
                       public string Surname { get; set; }
                       public string Cellphone { get; set; }
                       public string Address { get; set; }
                       public string CompanyName { get; set; }
                       public DateTime CurrentDate { get; set; }  
                       public void MyMethod() { }
                    }";
            sw.Start();
            string[] props =  GetProperties(s);
            sw.Stop();
            foreach (var item in props)
                Console.WriteLine(item);
            Console.WriteLine("\n\nMethod is executed in " + sw.ElapsedMilliseconds + " ms");
            Console.ReadKey();
