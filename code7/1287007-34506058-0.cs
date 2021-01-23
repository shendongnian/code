	//in your UserControlB.cs
	public event EventHandler<YourEventArgs> PointerPressed;
	private void OnPointerPressed() {
	    YourEventArgs arg = new YourEventArgs();
	    if (PointerPressed != null) {
	        PointerPressed(this, arg);
	    }
        if (PointerPressedCommand != null &&    PointerPressedCommand.CanExecute(PointerPressedCommandParameter)) {
	        PointerPressedCommand.Execute(PointerPressedCommandParameter);
	    }
	}
	#region PointerPressedCommand 
	public ICommand PointerPressedCommand
	{
	    get { return (ICommand)GetValue(PointerPressedCommandProperty); }
	    set { SetValue(PointerPressedCommandProperty, value); }
	}
	private readonly static FrameworkPropertyMetadata PointerPressedCommandMetadata = new FrameworkPropertyMetadata {
	    DefaultValue = null,
	    DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
	};
	public static readonly DependencyProperty PointerPressedCommandProperty = 
	    DependencyProperty.Register("PointerPressedCommand", typeof(ICommand), typeof(UserControlB), PointerPressedCommandMetadata);
	#endregion
