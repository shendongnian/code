    public class MyViewModel
    {
    	public SimpleModel Entity { get; set; }
    
    	private MyCommand _saveCommand;
    
    	public MyCommand SaveCommand { get { return _saveCommand ?? (_saveCommand = new MyCommand(OnSaveItem, parameter => CanSaveItem())); } }
    
    	public MyViewModel()
    	{
    		//------ You need to create an instance of your entity to bind to
    		Entity = new SimpleModel();
    		//-- I added an event handler as your "Entity" object doesn't know 
    		//-- about the button on the view model.  So when it has something
    		//-- change, have it call anybody listening to its exposed event.
    		Entity.SomethingChanged += MyMVVM_SomethingChanged;
    	}
    
    	void MyMVVM_SomethingChanged(object sender, EventArgs e)
    	{
    		// Tell our mvvm command object to re-check its CanExecute
    		SaveCommand.RaiseCanExecuteChanged();
    	}
    
    	public void OnSaveItem(object parameter)
    	{
    		// some code
    	}
    
    	public virtual bool CanSaveItem()
    	{
    		//-- Checking directly to your Entity object
    		return !String.IsNullOrWhiteSpace(Entity.Name);
    	}
    }
    
    
    public class SimpleModel
    {
   		//-- Simple constructor to default some values so when you run
   		//-- your form, you SHOULD see the values immediately to KNOW
   		//-- the bindings are correctly talking to this entity. 
    	public SimpleModel()
    	{
    		_name = "test1";
    		_Id = 123;
    	}
    
   		//-- changed to public and private... and notice in the setter
   		//-- to call this class's "somethingChanged" method
    	private int _Id;
    	public int Id
    	{
    		get { return _Id; }
    		set
    		{
    			_Id = value;
    			somethingChanged("Id");
    		}
    	}
    
    	private string _name;
    	public string Name 
    	{ get { return _name; }
    		set { _name = value;
    				somethingChanged( "Name" );
    		}
    	}
    
    	//-- Expose publicly for anything else to listen to (i.e. your view model)
    	public event EventHandler SomethingChanged;
   		//-- So, when any property above changes, it calls this method with whatever
   		//-- its property is just as a reference.  Then checks.  Is there anything
   		//-- listening to our exposed event handler?  If so, pass the information on
    	private void somethingChanged( string whatProperty)
    	{
    		// if something is listening
    		if (SomethingChanged != null)
    			SomethingChanged(whatProperty, null);
    	}
    	
    
    }
    
    
    public class MyCommand : ICommand
    {
    	public MyCommand(Action<object> execute, Predicate<object> canExecute)
    	{
    		_canExecute = canExecute;
    		_execute = execute;
    	}
    
    	public bool CanExecute(object parameter)
    	{
    		return _canExecute(parameter);
    	}
    
    	public void Execute(object parameter)
    	{
    		_execute(parameter);
    	}
    
    	private readonly Predicate<object> _canExecute;
    
    	private readonly Action<object> _execute;
    
   		//-- Change to the event handler definition, just expose it
    	public event EventHandler CanExecuteChanged;
    	//-- Now expose this method so your mvvm can call it and it rechecks 
   		//-- it's own CanExecute reference
    	public void RaiseCanExecuteChanged()
    	{
    		if (CanExecuteChanged != null)
    			CanExecuteChanged(this, new EventArgs());
    	}
    }
