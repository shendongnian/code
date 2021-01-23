    using System;
    using System.Xml;
    using System.Xml.Xsl; 
    
    namespace XSLTransform{
        class myclass
        {
            static void Main(string[] args)
            {
                XslTransform xslTran; 
                xslTran = new XslTransform();
                xslTran.Load("XSL PATH"); 
                xslTran.Transform("XML PATH"); 
            }
        }
    }
