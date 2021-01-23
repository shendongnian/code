    public partial class YourPage : System.Web.UI.Page,ITagable
    {
       public string Tag
       {
    	  set 
    	  { 
                //set the value to your div
    	        this.tagDiv.InnertText = value; 
    	  }
       }
    }
