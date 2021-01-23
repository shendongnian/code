    public class AttachCommandBindingsBehavior : Behavior<FrameworkElement>
    {
    	public ObservableCollection<CommandBinding> CommandBindings
    	{
    		get
    		{
    			return (ObservableCollection<CommandBinding>)GetValue(CommandBindingsProperty);
    		}
    		set
    		{
    			SetValue(CommandBindingsProperty, value);
    		}
    	}
    	public static readonly DependencyProperty CommandBindingsProperty = DependencyProperty.Register("CommandBindings", typeof(ObservableCollection<CommandBinding>), typeof(AttachCommandBindingsBehavior), new PropertyMetadata(null, OnCommandBindingsChanged));
    
    	private static void OnCommandBindingsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    	{
    		AttachCommandBindingsBehavior attachCommandBindingsBehavior = (AttachCommandBindingsBehavior)sender;
    
    		if (attachCommandBindingsBehavior == null)
    			return;
    
    		ObservableCollection<CommandBinding> commandBindings = (ObservableCollection<CommandBinding>)e.NewValue;
    
    		if (commandBindings != null)
    		{
    			if (attachCommandBindingsBehavior.CommandBindings != null)
    				attachCommandBindingsBehavior.CommandBindings.CollectionChanged -= attachCommandBindingsBehavior.CommandBindings_CollectionChanged;
    
    			attachCommandBindingsBehavior.CommandBindings.CollectionChanged += attachCommandBindingsBehavior.CommandBindings_CollectionChanged;
    		}
    	}
    
    	void CommandBindings_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    	{
    		ObservableCollection<CommandBinding> collection = (ObservableCollection<CommandBinding>)sender;
    
    		if (collection != null)
    		{
    			foreach (CommandBinding commandBinding in collection)
    				AssociatedObject.CommandBindings.Add(commandBinding);
    		}
    	}
    }
