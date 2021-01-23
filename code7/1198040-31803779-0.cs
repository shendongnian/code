    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
    	static void Main()
    	{
    		// create an XML document manually
    		var doc = XDocument.Load(new StringReader(@"<NewDataSet>
      <Table>
        <Id>1         </Id>
        <ProductName>Hp Laptop</ProductName>
        <SerialNumber>abc111    </SerialNumber>
        <Status>Delivered           </Status>
        <CustomerName>Shatakshi</CustomerName>
      </Table>
    </NewDataSet>"));
    		
    		// query the XML document
    		var product = doc
    			.Descendants("Table")
    			.Select(x => new {
    			        	Id = x.Element("Id").Value,
    		                ProductName = x.Element("ProductName").Value,
    		                SerialNumber = x.Element("SerialNumber").Value,
    		                Status = x.Element("Status").Value,
    		                CustomerName = x.Element("CustomerName").Value
    		                })
    			.FirstOrDefault();
    		
    		// print the result
    		if (product != null)
    		{
    			Console.WriteLine("Id = {0}", product.Id);
    			Console.WriteLine("Product Name = {0}", product.ProductName);
    			Console.WriteLine("Serial Number = {0}", product.SerialNumber);
    			Console.WriteLine("Status = {0}", product.Status);
    			Console.WriteLine("Customer Name = {0}", product.CustomerName);
    		}
    		
    		Console.Write("Press any key to continue . . . ");
    		Console.ReadKey(true);
    	}
    }
