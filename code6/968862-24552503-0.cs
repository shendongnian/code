    void Main()
    {
    	var firstMenuSection = new MenuSectionData{
    		Description = "First",
    		Links = new List<string> {"link 1", "link 2", "link 3", "link 4","link 5", "link 6","link 7", "link 8","link 9", "link 10","link 11", "link 12"}};
    		
    	var secondMenuSection = new MenuSectionData{
    		Description = "Second",
    		Links = new List<string> {"link 1", "link 2", "link 3", "link 4","link 5"}};
    		
    	var initialMenu = new List<MenuSectionData>{
    		firstMenuSection, secondMenuSection
    	};
    	
    	var menu = CreateConstrainedMenu(initialMenu, 12, 10);
    	
    	menu.Dump();
    }
    
    public List<MenuSectionData> CreateConstrainedMenu(List<MenuSectionData> initialMenu, int maxNumberOfLinks, int maxNumberOfLinksPerSection){
    	
    	int remainingLinks = maxNumberOfLinks;
    	foreach(var section in initialMenu){ 
    		var availableLinks = section.Links.Take(Math.Min(remainingLinks,maxNumberOfLinksPerSection)).ToList();  
    		section.Links = availableLinks;
    		remainingLinks -=  availableLinks.Count();
    	}
    	
    	return initialMenu;
    }
    
    public class MenuSectionData
    {
      public  string Description {get;set;}
      public List<string> Links {get;set;}
     }  
    
    // Define other methods and classes here
