    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataSet ds = new DataSet();
                ds.ReadXml(FILENAME, XmlReadMode.ReadSchema);
            }
       
        }
        
       
    }
