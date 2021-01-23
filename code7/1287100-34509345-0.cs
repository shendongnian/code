    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace stackexchange
    {
        class Program
        {
            private static string theXml = @"<?xml version='1.0' encoding='UTF-8'?>
        <Response>
            <IP>162.158.50.10</IP> //IP address
            <CountryCode>IN</CountryCode>   //Country Code
            <CountryName>India</CountryName>//Country Name
            <RegionCode>MH</RegionCode> //Region Code
            <RegionName>Maharashtra</RegionName>
            <City>Mumbai</City>
            <ZipCode></ZipCode>
            <TimeZone>Asia/Kolkata</TimeZone>
            <Latitude>18.975</Latitude>
            <Longitude>72.8258</Longitude>
            <MetroCode>0</MetroCode>
        </Response>";
            static void Main(string[] args)
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(theXml);
                XmlNode ip = xml.SelectSingleNode("/Response/IP");
                Console.Out.WriteLine($"Ip Address: {ip.InnerText}");
    
                XElement root = XElement.Parse(theXml);
                XElement address = (from a in root.Descendants() where a.Name == "IP" select a).Single();
                Console.Out.WriteLine($"Ip Address: {address.Value}");
            }
        }
    }
