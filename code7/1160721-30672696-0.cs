    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <OrderResult xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
        <Status>Success</Status>
        <OrderID>159E6B2AE35244DB984384DBD7DC</OrderID>
        <Errors>
            <Error>
                <Code>1000</Code>
                <Message> StopType not valid. Submitted TripSheet data has been ignored.</Message>
                <Severity>Unknown</Severity>
            </Error>
            <Error>
                <Code>1000</Code>
                <Message> StopType not valid. Submitted TripSheet data has been ignored.</Message>
                <Severity>Unknown</Severity>
            </Error>
        </Errors>
    </OrderResult>";
    
                XDocument doc = XDocument.Parse(xml);
                MemoryStream ms = new MemoryStream();
                doc.Save(ms);
                ms.Position = 0;
    
                XmlSerializer ser = new XmlSerializer(typeof(OrderResult));
                var orderresult = ser.Deserialize(ms) as OrderResult;
    
                Console.WriteLine(orderresult.OrderID);
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class OrderResult
        {
    
            private string statusField;
    
            private string orderIDField;
    
            private OrderResultError[] errorsField;
    
            /// <remarks/>
            public string Status
            {
                get
                {
                    return this.statusField;
                }
                set
                {
                    this.statusField = value;
                }
            }
    
            /// <remarks/>
            public string OrderID
            {
                get
                {
                    return this.orderIDField;
                }
                set
                {
                    this.orderIDField = value;
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("Error", IsNullable = false)]
            public OrderResultError[] Errors
            {
                get
                {
                    return this.errorsField;
                }
                set
                {
                    this.errorsField = value;
                }
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class OrderResultError
        {
    
            private ushort codeField;
    
            private string messageField;
    
            private string severityField;
    
            /// <remarks/>
            public ushort Code
            {
                get
                {
                    return this.codeField;
                }
                set
                {
                    this.codeField = value;
                }
            }
    
            /// <remarks/>
            public string Message
            {
                get
                {
                    return this.messageField;
                }
                set
                {
                    this.messageField = value;
                }
            }
    
            /// <remarks/>
            public string Severity
            {
                get
                {
                    return this.severityField;
                }
                set
                {
                    this.severityField = value;
                }
            }
        }
    }
