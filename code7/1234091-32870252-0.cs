    public class Project{
	     public string Id { get; set; }
         public string Title { get; set; }
         public string Status { get; set; }
         public string GetExternalUrl() {
		     return "http://yoursite.com/" + Id; 
	     }
    }
