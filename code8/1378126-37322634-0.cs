    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.IO;
    namespace _37321906
    {
        class Program
        {
            static void Main(string[] args)
            {
                Root root = new Root();
                root.Data.Struct.PartnerCD = 123;
                root.Data.Struct.UserName = "api";
                root.Data.Struct.Password = "pass";
                root.Data.Struct.Action = "token";
                root.Data.Struct.Token = 4847898;
                root.Data.Struct.Products.Product.Add(new Product { ProductID = 123, SVA = "e8a8227c-bba3-4f32-a2cd-15e8f246344b", Amount = 700.0001 });
                // Serialize the root object to XML
                Serialize<Root>(root);
                // Deserialize from XML
                Root DeserializeRoot = Deserialize<Root>();
            }
            private static void Serialize<T>(T data)
            {
                // Use a file stream here.
                using (TextWriter WriteFileStream = new StreamWriter("test.xml"))
                {
                    // Construct a SoapFormatter and use it  
                    // to serialize the data to the stream.
                    XmlSerializer SerializerObj = new XmlSerializer(typeof(T));
                    try
                    {
                        // Serialize EmployeeList to the file stream
                        SerializerObj.Serialize(WriteFileStream, data);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(string.Format("Failed to serialize. Reason: {0}", ex.Message));
                    }
                }
            }
            private static T Deserialize<T>() where T : new()
            {
                //List<Employee> EmployeeList2 = new List<Employee>();
                // Create an instance of T
                T ReturnListOfT = CreateInstance<T>();
                // Create a new file stream for reading the XML file
                using (FileStream ReadFileStream = new FileStream("test.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    // Construct a XmlSerializer and use it  
                    // to serialize the data from the stream.
                    XmlSerializer SerializerObj = new XmlSerializer(typeof(T));
                    try
                    {
                        // Deserialize the hashtable from the file
                        ReturnListOfT = (T)SerializerObj.Deserialize(ReadFileStream);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(string.Format("Failed to serialize. Reason: {0}", ex.Message));
                    }
                }
                // return the Deserialized data.
                return ReturnListOfT;
            }
            // function to create instance of T
            public static T CreateInstance<T>() where T : new()
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }
        [XmlRoot(ElementName = "Product")]
        public class Product
        {
            [XmlElement(ElementName = "ProductID")]
            public int ProductID { get; set; }
            [XmlElement(ElementName = "SVA")]
            public string SVA { get; set; }
            [XmlElement(ElementName = "Amount")]
            public double Amount { get; set; }
        }
        [XmlRoot(ElementName = "Products")]
        public class Products
        {
            public Products()
            {
                this.Product = new List<Product>();
            }
            [XmlElement(ElementName = "Product")]
            public List<Product> Product { get; set; }
        }
        [XmlRoot(ElementName = "struct")]
        public class Struct
        {
            public Struct()
            {
                this.Products = new Products();
            }
            [XmlElement(ElementName = "PartnerCD")]
            public int PartnerCD { get; set; }
            [XmlElement(ElementName = "UserName")]
            public string UserName { get; set; }
            [XmlElement(ElementName = "Password")]
            public string Password { get; set; }
            [XmlElement(ElementName = "Action")]
            public string Action { get; set; }
            [XmlElement(ElementName = "OfficeCD")]
            public string OfficeCD { get; set; }
            [XmlElement(ElementName = "ChannelCD")]
            public string ChannelCD { get; set; }
            [XmlElement(ElementName = "Token")]
            public int Token { get; set; }
            [XmlElement(ElementName = "Notes")]
            public string Notes { get; set; }
            [XmlElement(ElementName = "Products")]
            public Products Products { get; set; }
        }
        [XmlRoot(ElementName = "data")]
        public class Data
        {
            public Data()
            {
                this.Struct = new Struct();
            }
            [XmlElement(ElementName = "struct")]
            public Struct Struct { get; set; }
        }
        [XmlRoot(ElementName = "root")]
        public class Root
        {
            public Root()
            {
                this.Data = new Data();
            }
            [XmlElement(ElementName = "data")]
            public Data Data { get; set; }
        }
    }
