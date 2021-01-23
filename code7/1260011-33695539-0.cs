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
                string cityXML =
                "<City>" +
                    "<ID>city1</ID>" +
                    "<Grid_ref>NG 895608</Grid_ref>" +
                    "<Name>Berlin</Name>" +
                    "<Country>Germany</Country>" +
                "</City>";
                XElement city = XElement.Parse(cityXML);
                string weatherXML =
                "<cityWeather>" +
                    "<ID>c1</ID>" +
                    "<temperature>20</temperature>" +
                    "<wind>2</wind>" +
                "</cityWeather>";
                XElement weather = XElement.Parse(weatherXML);
                city.Add(weather);
            }
        }
    }
    ​
