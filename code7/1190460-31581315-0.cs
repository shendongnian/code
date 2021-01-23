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
                //<Conquest><User>ArchElf</User><Token>0123456789012345678901234567890</Token><Command>validate</Command><Parameter Id=\"1\">Gemstone3</Parameter>
                string user = "ArchElf";
                string token = "0123456789012345678901234567890";
                string command = "validate";
                int id = 1;
                string value = "Gemstrone3";
                XElement conquest = new XElement("Conquest");
                conquest.Add(new XElement("User", user));
                conquest.Add(new XElement("Token", token));
                conquest.Add(new XElement("Command", command));
                XElement e_parameter = new XElement("Parameter", value);
                e_parameter.Add(new XAttribute("Id", id));
                conquest.Add(e_parameter);
            }
        }
    }
    ​
