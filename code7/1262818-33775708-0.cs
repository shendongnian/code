    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    public class MainClass
{
    public static void Main()
    {
        XmlDocument mDocument = new XmlDocument();
        XmlNode mCurrentNode;
        mDocument.Load("XPathQuery.xml");
        mCurrentNode = mDocument.DocumentElement;
        XmlNodeList nodeList = mCurrentNode.SelectNodes("*");
        DisplayList(nodeList);
    }
    static void DisplayList(XmlNodeList nodeList)
    {
        foreach (XmlNode node in nodeList)
        {
            RecurseXmlDocumentNoSiblings(node);
        }
    }
    static void RecurseXmlDocumentNoSiblings(XmlNode root)
    {
        if (root is XmlElement)
        {
            Console.WriteLine(root.Name);
            if (root.HasChildNodes)
                RecurseXmlDocument(root.FirstChild);
        }
        else if (root is XmlText)
        {
            string text = ((XmlText)root).Value;
            Console.WriteLine(text);
        }
        else if (root is XmlComment)
        {
            string text = root.Value;
            Console.WriteLine(text);
            if (root.HasChildNodes)
                RecurseXmlDocument(root.FirstChild);
        }
    }
    static void RecurseXmlDocument(XmlNode root)
    {
        if (root is XmlElement)
        {
            Console.WriteLine(root.Name);
            if (root.HasChildNodes)
                RecurseXmlDocument(root.FirstChild);
            if (root.NextSibling != null)
                RecurseXmlDocument(root.NextSibling);
        }
        else if (root is XmlText)
        {
            string text = ((XmlText)root).Value;
            Console.WriteLine(text);
        }
        else if (root is XmlComment)
        {
            string text = root.Value;
            Console.WriteLine(text);
            if (root.HasChildNodes)
                RecurseXmlDocument(root.FirstChild);
            if (root.NextSibling != null)
                RecurseXmlDocument(root.NextSibling);
        }
    }
