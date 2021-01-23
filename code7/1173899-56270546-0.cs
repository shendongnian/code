	using System;
	using System.Collections.Generic;
	using System.Linq;
						
	public class Program
	{
		class Menu {
		  public int Section {get; set;}
		  public string Parent {get; set;}
		  public string Name {get; set;}
		  public string Url {get; set;}
		}
		
		public static void Main()
		{ 
			var menuList = new List<Menu>();
			
			ILookup<int, ILookup<string, Menu>> MenuStructure = 
				 menuList.GroupBy(m => m.Section).ToLookup(g => g.Key, v => v.ToLookup(m => m.Parent));
		}
	}
