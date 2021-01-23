    using System;    
					
    public class Program
    {
	  public static void Main()
	  {
		string[] vowels = new string[]{"A","E","I","O","U"};
		
           
                string[] names = new string[5];
                names[0] = "john";
                names[1] = "samuel";
                names[2] = "kevin";
                names[3] = "steve";
				names[4] = "martyn";
				
				for (int i = 0; i < names.Length; i++)
				{
				    foreach(var v in vowels)
					{
						
						if(names[i].ToString().ToUpper().Contains(v.ToString()))
					    {
							Console.WriteLine(names[i]);
							names[i] = names[i].ToString().ToUpper().Replace(v.ToString(), "");
							Console.WriteLine("The output is: "+names[i].ToString().ToLower());
					    }
					}
				}
			
                Console.ReadLine();
	   }
    }
