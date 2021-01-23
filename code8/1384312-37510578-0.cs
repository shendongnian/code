    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Customer> customers = new List<Customer>();
                Customer Cus = new Customer()
                {
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    Product = new List<Product> {
                        new Product()
                        {
                            ProductColor = "ProductColor12",
                            ProductNumber = 12
                        },
                        new Product()
                        {
                            ProductColor = "ProductColor11",
                            ProductNumber = 11
                        }
                    }
                };
                customers.Add(Cus);
                var results = customers.OrderBy(x => x.LastName).ThenBy(y => y.FirstName).Select(z => z.Product.OrderBy(a => a.ProductNumber)).ToList();
            }
        }
        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<Product> Product { get; set; }
        }
        public class Product
        {
            public int ProductNumber { get; set; }
            public string ProductColor { get; set; }
        }
    }
