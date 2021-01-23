    using System;
    using System.Xml.Linq;
    using System.Xml;
    
    public class Program
    {
    	public static void Main()
    	{
    		var xml = @"<Root>
      <Marys_basket numFruits=""2"">
         <Fruit name=""Mango""/>
         <Fruit name=""Papaya""/>
      </Marys_basket>
      <Jons_basket numFruits=""0"" />
      <Bobs_basket numFruits=""1""> 
         <Fruit name=""Apple""/>
      </Bobs_basket>
    </Root>";
    		var doc = XDocument.Parse(xml);
    		XElement basket = doc.Root.Element("Marys_basket");
    		basket.FirstAttribute.SetValue((int)basket.FirstAttribute + 1);
    		Console.WriteLine(doc.ToString());
    	}
    }
