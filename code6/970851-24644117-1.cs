    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace LinqQuerySyntaxDemo
    {
        public class Program
        {
            static public void Main(string[] args)
            {
                string customerName = "bla1";
                
                XElement dataElem = XElement.Parse(GetXml());
                
                var ipAddresses =
                    from customerElem in dataElem.Elements("Customer")
                    where (string)customerElem.Element("Name") == customerName
                    from ipElem in customerElem.Descendants("IP")
                    select (string)ipElem;
                
                foreach (var ipAddress in ipAddresses)
                {
                    Console.WriteLine("[{0}]", ipAddress);
                }
            }
    
            static string GetXml()
            {
                return
                   @"<Data>
                       <Customer>
                         <Name>bla1</Name>
                           <d1>
                             <IP>888.888.888.888</IP>
                             <UserLogin>userxy</UserLogin>
                             <UserPw>pwxy</UserPw>
                           </d1>
                           <d2>
                             <IP>889.889.889.889</IP>
                             <UserLogin>userzp</UserLogin>
                             <UserPw>pwzp</UserPw>
                           </d2>
                       </Customer>
                     </Data>";
            }
        }
    }
