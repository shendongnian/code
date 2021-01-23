    void Main()
    {
    	var vm = new MainVM(new FooFactory());
    	Console.WriteLine(vm.Posts);
    	vm.ExecuteFoo();
    	Console.WriteLine(vm.Posts);	
    }
    
    public class Foo
    {
    	private Action _action;
    	public Foo(Action action)
    	{
    		_action = action;
    	}
    
    	public void RunAction()
    	{
    		_action();
    	}
    }
    
    public class FooFactory
    {	
    	public Foo[] CreateFoo(MainVM vm)
    	{
    		return new[] { new Foo(()=>vm.Posts++) };
    	}
    }
    
    public class MainVM : INotifyPropertyChanged
    {
    	public MainVM(FooFactory factory)
    	{
    		_foos = factory.CreateFoo(this);
    	}
    
    	public void ExecuteFoo()
    	{
    		foreach(var foo in _foos)
    		foo.RunAction();
    	}
    	
    	private Foo[] _foos;
    
    	private int posts;
    	public int Posts
    	{
    		get { return this.posts; }
    		set
    		{
    			this.posts = value;
    			this.OnPropertyChanged();
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	private void OnPropertyChanged([CallerMemberName]string propertyName = null)
    	{		
    		var local = PropertyChanged;
    		if (local != null)
    		{
    			local(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    }
