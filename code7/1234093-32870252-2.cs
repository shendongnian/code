    public class Project{
	     public string Id { get; set; }
         public string Title { get; set; }
         public string Status { get; set; }
         string _externalUrl;
         public string GetExternalUrl() {
             if(string.IsNullOrWhiteSpace(_externalUrl))
  		         _externalUrl = "http://yoursite.com/" + Id; 
             return _externalUrl;
	     }
    }
