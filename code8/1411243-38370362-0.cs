    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
             static void Main(string[] args)
             {
                 Product product = new Product()
                 {
                     id = 123,
                     title = "A Long Way Home",
                     desc = "Welcome",
                     price = 456.78F,
                     category = new Category() { name = "John" }
                 };
                 XElement xProduct = new XElement("Product", new object[] {
                     new XElement("Id", product.id),
                     new XElement("Title", product.title),
                     new XElement("Description", product.desc),
                     new XElement("Price", product.price),
                     new XElement("Category", product.category)
                 });
            }
        }
        public class Product
        {
            public int id { get; set; }
            public string title { get; set; }
            public string desc { get; set; }
            public float price { get; set; }
            public Category category { get; set; }
        }
        public class Category
        {
            public string name { get; set; }
        }
     }
