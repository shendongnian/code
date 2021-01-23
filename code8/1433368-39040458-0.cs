    using System;
    using System.Xml;
    namespace parseXML
    {
    class Program
    {
    public static void Main(string[] args)
    {
    XmlDocument doc = new XmlDocument();
    doc.Load("parse.xml");
    XmlNode child; 
    int count=doc.GetElementsByTagName("dsml:attr").Count;
    for(int i=0;i<=count-1;i++)
    {
    child=doc.GetElementsByTagName("dsml:attr")[i];
    Console.WriteLine(i);
    Console.WriteLine("dsml:attr>> "+child.Attributes["name"].Value);
    Console.WriteLine("dsml:value>> "+child.ChildNodes[0].InnerText);
    }
    Console.ReadKey(true);
    }}}
