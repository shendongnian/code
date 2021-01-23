    public class FormEvents : BindableBase
    {
       private string someName;
    	public string SomeName
    	{
    		get {return someName;}
    		set { SetProperty(ref someName, value);}
    	}
    	
    	public FormEvents()
    	{
    	    DXTabItem myTabItem= new DXTabItem();
            myTabItem.Header = new Label()
            { 
                Name= "lblTabAccountHeader", 
                Content = "MyTab" + Convert.ToString(UserID) 
            };
    		SomeName = lblTabAccountHeader.Content;
    	}
    }
