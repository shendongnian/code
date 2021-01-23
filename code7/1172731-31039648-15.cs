    using System.Collections.Generic;
    
    namespace HelloWorld
    {
    	public class MyViewModel
    	{
    		public int SelectedPersonID { get; set; }
    		public List<Person> Persons { get; set; }
    	}
    	
    	public class Person
    	{
    		public int PersonID  { get; set; }
    		public string First { get; set; }
    		public string Last { get; set; }
    		public string NameFull
    		{
    			get {
    			
    				return First + " " + Last;
    			}
    		}
    	}
    }
