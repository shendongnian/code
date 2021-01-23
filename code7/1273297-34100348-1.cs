    using System;
    using System.Xml;
    using System.Xml.Xsl; 
    namespace XSLTransformation
    {
        class Class1
        {
            static void Main(string[] args)
            {
                XslTransform myXslTransform; 
                myXslTransform = new XslTransform();
                myXslTransform.Load("XSLTScript.xsl"); 
                myXslTransform.Transform("InputXML.xml", "OutpuXML.xml"); 
    
            }
        }
    }
    	
 
