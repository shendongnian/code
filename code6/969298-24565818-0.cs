    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace LinqToXmlDemo
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                string xmlContent = GetXml();
                
                XElement arrayOfOrder = XElement.Parse(xmlContent);
                
                XElement order = arrayOfOrder.Element("Order");
                string orderId = (string)order.Element("Id");            
                
                XElement billingAddress = order.Element("BillingAddress");
                string firstName = (string)billingAddress.Element("FirstName");
                string lastName = (string)billingAddress.Element("LastName");
                
                Console.WriteLine("[{0}] [{1}] [{2}]",
                    orderId,
                    firstName,
                    lastName);
            }
    
            private static String GetXml()
            {
                return
                    @"<?xml version='1.0' encoding='utf-8'?>
                      <ArrayOfOrder>
                        <Order>
                          <Id>1</Id>
                          <OrderGuid />
                          <BillingAddress>
                            <Id>0</Id>
                            <FirstName>Harvey</FirstName>
                            <LastName>Danger</LastName>
                          </BillingAddress>
                          <OrderItems>
                            <OrderItem>
                              <ProductName>Silver Widgets</ProductName>
                              <Price>9.99</Price>
                              <Quantity>10</Quantity>
                              <OrderDate>7/2/2014 2:05:00 PM</OrderDate>
                              <Barcodes>
                                <BarCode>
                                  <string>123CC2D68</string>
                                </BarCode>
                              </Barcodes>
                            </OrderItem>
                          </OrderItems>
                        </Order>
                      </ArrayOfOrder>";
            }        
        }
    }
