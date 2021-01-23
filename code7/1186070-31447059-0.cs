    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    namespace Test
    {
        // This is the test class we want to serialize: 
        [Serializable()]
        public class TestClass
        {
            private string someString;
            public string SomeString
            {
                get { return someString; }
                set { someString = value; }
            }
            private List<string> settings = new List<string>();
            public List<string> Settings
            {
                get { return settings; }
                set { settings = value; }
            }
            // These will be ignored 
            [NonSerialized()]
            private int willBeIgnored1 = 1;
            private int willBeIgnored2 = 1;
        }
        internal class Program
        {
            private static void Main(string[] args)
            {
                // Example code 
                // This example requires: using System.Xml.Serialization; using System.IO; 
                // Create a new instance of the test class 
                TestClass data = new TestClass();
                // Set some dummy values 
                data.SomeString = "foo";
                for (int a = 0; a < 1000000; a++) // 100000 = 8,4 mb // 1000000 = 87 MB // 10000000 will crash the serializer ^^
                {
                    data.Settings.Add("A" + a);
                    data.Settings.Add("B" + a);
                    data.Settings.Add("C" + a);
                }
                StringWriter stringWriter = new System.IO.StringWriter();
                XmlSerializer serializer = new XmlSerializer((typeof(TestClass)));
                serializer.Serialize(stringWriter, data);
                string xmlString = ""; //  stringWriter.ToString();
                using (MemoryStream ms = new MemoryStream())
                {
                    new XmlSerializer(typeof(TestClass)).Serialize(ms, data);
                    ms.Position = 0;
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        xmlString = sr.ReadToEnd();
                    }
                }
                File.WriteAllText(@"c:\Temp\out.xml", xmlString);
                ;
            }
        }
    }
