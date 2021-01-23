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
                List<Entity> cEntities = new List<Entity>();
                string input =
                    "<Entities TotalResult=\"3\">" +
                        "<Entity Type=\"test-set-folder\">" +
                          "<Fields>" +
                              "<Field Name=\"id\">" +
                                "<Value>12457</Value>" +
                              "</Field>" +
                              "<Field Name=\"parent-id\">" +
                                "<Value>0</Value>" +
                              "</Field>" +
                              "<Field Name=\"last-modified\">" +
                                "<Value>2015-03-09 14:09:57</Value>" +
                              "</Field>" +
                              "<Field Name=\"description\">" +
                                 "<Value/>" +
                              "</Field>" +
                              "<Field Name=\"view-order\"/>" +
                              "<Field Name=\"name\">" +
                                "<Value>.NET</Value>" +
                              "</Field>" +
                         "</Fields>" +
                       "</Entity>" +
                       "<Entity Type=\"test-set-folder\">" +
                         "<Fields>" +
                            "<Field Name=\"id\">" +
                               "<Value>15487</Value>" +
                            "</Field>" +
                            "<Field Name=\"parent-id\">" +
                              "<Value>0</Value>" +
                            "</Field>" +
                            "<Field Name=\"last-modified\">" +
                              "<Value>2015-03-15 13:00:02</Value>" +
                            "</Field>" +
                            "<Field Name=\"description\">" +
                              "<Value/>" +
                            "</Field>" +
                            "<Field Name=\"view-order\"/>" +
                            "<Field Name=\"name\">" +
                              "<Value>Python</Value>" +
                            "</Field>" +
                         "</Fields>" +
                      "</Entity>" +
                    "</Entities>";
                
                XElement entities = XElement.Parse(input);
                foreach (XElement entity in entities.Descendants("Entity"))
                {
                    Entity newEntity = new Entity();
                    cEntities.Add(newEntity);
                    foreach (XElement field in entity.Descendants("Field"))
                    {
                        string name = field.Attribute("Name").Value;
                        string value = field.Element("Value") == null ? "" : field.Element("Value").Value;
                        switch (name)
                        {
                            case "id" :
                                newEntity.id = int.Parse(value);
                                break;
                            case "parent-id":
                                newEntity.parent_id = int.Parse(value);
                                break;
                            case "last-modified":
                                newEntity.last_modified = DateTime.Parse(value);
                                break;
                            case "description":
                                newEntity.description = value;
                                break;
                            case "view-order":
                                newEntity.view_order = value;
                                break;
                            case "name":
                                newEntity.name = value;
                                break;
                        }
                    }
                }
            }
            public class Entity
            {
                public int id { get; set; }
                public int parent_id { get; set; }
                public DateTime last_modified { get; set; }
                public string description { get; set; }
                public string view_order { get; set; }
                public string name { get; set; }
            }
        }
    }
    ​
