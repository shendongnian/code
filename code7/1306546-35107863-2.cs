    public class ViewModel
    {
           private readonly System.Collections.Generic.List<IceCreamFlavor> _flavors;
    
    		public ViewModel()
    		{
    		 // Construct Flavors
    		}
    		
    		public List<IceCreamFlavor> AllFlavors
    		{
    			get
    			{
    				return _flavors;	
    			}
    		}
    		
    		[Display(Name = "Favorite Flavor")]
    		public int SelectedFlavorId { get; set; }
    	
    		public System.Web.Mvc.SelectList FlavorItems
    		{
    			get { return new System.Web.Mvc.SelectList(_flavors, "Id", "Name");}
    		}
    	}
