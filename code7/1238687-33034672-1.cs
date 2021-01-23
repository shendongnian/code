      static void Main()
        {
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
            string[] props =  GetProperties(s);
            foreach (var item in props)
                Console.WriteLine(item);
            Console.ReadKey();
        }
