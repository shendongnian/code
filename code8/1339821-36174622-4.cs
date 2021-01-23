    using System;
    using System.Text;
    
    public class Example
    {
       public static void Main()
       {
    	     
    	  string[] names = { "Banana Large Yellow", "Brie Cheese", "Indian Mango Box"};
    	  int[] quantities = { 1,3,10}; 
    	  decimal[] prices = { 2.00m, 30.00m, 246.00m};
    	  
    	  string format = "{0,-25} {1,-10} {2,10}" + Environment.NewLine;
          var stringBuilder = new StringBuilder().AppendFormat(format, "Item Name", "QTY", "Price");
          for (int i = 0; i < names.Length; i++)
    	  {
    		  stringBuilder.AppendFormat(format, names[i], quantities[i], prices[i]);
    	  }
    
    	  Console.WriteLine(stringBuilder.ToString());
    
       }
    }
    Item Name                 QTY             Price
    Banana Large Yellow       1                2.00
    Brie Cheese               3               30.00
    Indian Mango Box          10             246.00
