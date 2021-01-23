    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Xsl;
    
    namespace ConsoleApplication1
    {
       class Program
       {
           static void Main(string[] args)
           {
               try
               {
                   XmlDocument doc = new XmlDocument();
                   doc.Load(@"c:\users\prasath\documents\visualio
        2010\Projects\ConsoleApplication1\ConsoleApplication1\book.xml");
                   XslCompiledTransform xslt = new XslCompiledTransform();
                   xslt.Load(@"c:\users\prasath\documents\visualio
        2010\Projects\ConsoleApplication1\ConsoleApplication1\book.xsl");
                   XmlTextWriter wrt = new XmlTextWriter(Console.Out); //
                   //should probably be a StreamWriter in real code
                   wrt.Formatting = Formatting.Indented;
                   xslt.Transform(doc, wrt);
                   Console.ReadKey();
               }
           }
       }
