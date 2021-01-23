    using System.Collections.Generic;
    
    namespace HelloWorld
    {
    	public class MyViewModel
    	{
    		public Person SelectedPerson { get; set; }
    		public List<Person> Persons { get; set; }
    	}
    	
    	public class Person
    	{
    		public int PersonID { get; set; }
    		
    		public string NameFull
    		{
    			get {
    			
    				return First + " " + Last;
    			}
    		}
    
    		public string First { get; set; }
    
    		public string Last { get; set; }
    	}
    }
