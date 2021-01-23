    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                        "<categories type=\"array\">" +
                           "<category>" +
                              "<parent-id />" +
                              "<name>Şirketiçi</name>" +
                              "<count type=\"integer\">0</count>" +
                              "<elements-count type=\"integer\">0</elements-count>" +
                              "<id type=\"integer\">18940</id>" +
                              "<type>ProjectCategory</type>" +
                           "</category>" +
                        "</categories>";
                XDocument doc = XDocument.Parse(input);
                List<Category> categories = new List<Category>();
                foreach (XElement category in doc.Descendants("category"))
                {
                    Category newCategory = new Category();
                    categories.Add(newCategory);
                    newCategory.parentID = category.Element("parent-id") == null  ? null : category.Element("parent-id").Value.Length == 0 ? null : (int?)category.Element("parent-id");
                    newCategory.name = category.Element("name") == null ? null : category.Element("name").Value.Length == 0 ? null : (string)category.Element("name");
                    newCategory.count = category.Element("count") == null ? null : category.Element("count").Value.Length == 0 ? null : (int?)category.Element("count");
                    newCategory.elementsCount = category.Element("elements-count") == null ? null : category.Element("elements-count").Value.Length == 0 ? null : (int?)category.Element("elements-count");
                    newCategory.id = category.Element("id") == null ? null : category.Element("id").Value.Length == 0 ? null : (int?)category.Element("id");
                    newCategory._type = category.Element("type") == null ? null : (string)category.Element("type");
                }
            }
            public class Category
            {
                public int? parentID { get; set; }
                public string name { get; set; }
                public int? count { get; set; }
                public int?  elementsCount { get; set; }
                public int? id { get; set; }
                public string _type { get; set; }
            }
        }
    }
    ​
