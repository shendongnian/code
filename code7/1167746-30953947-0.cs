    public class BindingClass
    {
    	public BindingClass (string title)
    	{
    		this.TestCommand = new TestCommandImpl (this);
    		this.Title = title;
    	}
    
    	public string Title { get; }
    	public ICommand TestCommand { get; }
    	public BindingClass Parent { get; set; }
    }
