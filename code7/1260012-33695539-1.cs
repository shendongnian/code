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
                "<Root>" +
                    "<City>" +
                        "<ID>city1</ID>" +
                        "<Grid_ref>NG 895608</Grid_ref>" +
                        "<Name>Berlin</Name>" +
                        "<Country>Germany</Country>" +
                    "</City>" +
                    "<City>" +
                        "<ID>city2</ID>" +
                        "<Grid_ref>F 5608</Grid_ref>" +
                        "<Name>Paris</Name>" +
                        "<Country>France</Country>" +
                    "</City>" +
                    "<City>" +
                        "<ID>city3</ID>" +
                        "<Grid_ref>RR 608</Grid_ref>" +
                        "<Name>Rome</Name>" +
                        "<Country>Italy</Country>" +
                    "</City>" +
                 "</Root>";
      
                XElement cities = XElement.Parse(cityXML);
                string weatherXML =
                "<Root>" +
                   "<City>" +
                        "<Name>Berlin</Name>" +
                        "<Country>Germany</Country>" +
                        "<cityWeather>" +
                            "<ID>c1</ID>" +
                            "<temperature>20</temperature>" +
                            "<wind>2</wind>" +
                        "</cityWeather>" +
                    "</City>" +
                   "<City>" +
                        "<Name>Paris</Name>" +
                        "<Country>France</Country>" +
                        "<cityWeather>" +
                            "<ID>c2</ID>" +
                            "<temperature>30</temperature>" +
                            "<wind>3</wind>" +
                        "</cityWeather>" +
                    "</City>" +
                   "<City>" +
                        "<Name>Rome</Name>" +
                        "<Country>Italy</Country>" +
                        "<cityWeather>" +
                            "<ID>c3</ID>" +
                            "<temperature>40</temperature>" +
                            "<wind>4</wind>" +
                        "</cityWeather>" +
                    "</City>" +
                "</Root>";
                XElement weather = XElement.Parse(weatherXML);
                List<XElement> cityList = cities.Descendants("City").ToList(); 
                foreach(XElement city in cityList)
                {
                    XElement matchedCity = weather.Descendants("City").Where(x =>
                        (x.Element("Name").Value == city.Element("Name").Value) &&
                        (x.Element("Name").Value == city.Element("Name").Value)).FirstOrDefault();
                    if(matchedCity != null) city.Add(matchedCity.Element("cityWeather"));
                }
            }
        }
    }
    ​
