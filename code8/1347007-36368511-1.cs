    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
			var index = 0;
			var myArray = new string[25];
			var isEmptyText = false;
			do
			{
				Console.Write("Give me some input or press enter to quit: ");
				var result = Console.ReadLine();
				isEmptyText = string.IsNullOrWhiteSpace(result);
				if (!isEmptyText) 
				{
					if (myArray.Length <= index) 
					{
						Array.Resize(ref myArray, myArray.Length + 10);
					}
	
					myArray[index++] = result;
				}
			} while (!isEmptyText);
			
			Console.WriteLine(myArray.Length);
			for (var i=0; i < index; i++) 
			{
				Console.Write((i==0 ? "" : ", ") + myArray[i]);
			}
    	}
    }
