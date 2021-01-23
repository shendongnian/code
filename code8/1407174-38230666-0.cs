    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string text = "<li class=\"active-result group-option\" data-option-array-index=\"4\">Microsoft Power BI</li>";
                //use only for reading from string.
                StringReader reader = new StringReader(text);
                List<string> data = new List<string>();
                //for reading from file use XmlReader.Create(filename);
                XmlReader xReader = XmlReader.Create(reader);
                while(!xReader.EOF)
                {
                    if(xReader.Name != "li")
                    {
                        xReader.ReadToFollowing("li");
                    }
                    if(!xReader.EOF)
                    {
                        data.Add(xReader.ReadInnerXml());
                    }
                }
            }
        }
    }
