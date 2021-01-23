    public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(Button), null, propertyChanged: (bo, o, n) => ((Button)bo).OnCommandChanged());
    
    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(Button), null,
    			propertyChanged: (bindable, oldvalue, newvalue) => ((Button)bindable).CommandCanExecuteChanged(bindable, EventArgs.Empty));
    
    public ICommand Command
    		{
    			get { return (ICommand)GetValue(CommandProperty); }
    			set { SetValue(CommandProperty, value); }
    		}
    
    		public object CommandParameter
    		{
    			get { return GetValue(CommandParameterProperty); }
    			set { SetValue(CommandParameterProperty, value); }
    		}
    
    public event EventHandler Clicked;
    void IButtonController.SendClicked()
    		{
    			ICommand cmd = Command;
    			if (cmd != null)
    				cmd.Execute(CommandParameter);
    
    			EventHandler handler = Clicked;
    			if (handler != null)
    				handler(this, EventArgs.Empty);
    		}
