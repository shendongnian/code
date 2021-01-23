    public class PasswordBoxBehavior : Behavior<PasswordBox>
    {
    	public bool ResetPassword
    	{
    		get { return (bool)GetValue(ResetPasswordProperty); }
    		set { SetValue(ResetPasswordProperty, value); }
    	}
    
    	// Using a DependencyProperty as the backing store for ResetPassword.  This enables animation, styling, binding, etc...
    	public static readonly DependencyProperty ResetPasswordProperty =
    		DependencyProperty.Register("ResetPassword", typeof(bool), typeof(PasswordBoxBehavior), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnResetPasswordChanged));
    
    	static void OnResetPasswordChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
    	{
    		PasswordBoxBehavior behavior = depObj as PasswordBoxBehavior;
    		PasswordBox item = behavior.AssociatedObject as PasswordBox;
    		if (item == null)
    			return;
    
    		if ((bool)e.NewValue)
    			item.Password = string.Empty;
    
    		behavior.ResetPassword = false;
    	}
    
    	private bool isRoutedEventHandlerAssign;
    	public string Text
    	{
    		get { return (string)GetValue(TextProperty); }
    		set { SetValue(TextProperty, value); }
    	}
    
    	// Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
    	public static readonly DependencyProperty TextProperty =
    		DependencyProperty.Register("Text", typeof(string), typeof(PasswordBoxBehavior), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnTextChanged));
    
    	static void OnTextChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
    	{
    		PasswordBoxBehavior behavior = depObj as PasswordBoxBehavior;
    		PasswordBox item = behavior.AssociatedObject as PasswordBox;
    		if (item == null)
    			return;
    
    		if (item.Password != e.NewValue as string)
    		{
    			item.Password = e.NewValue as string;
    		}
    
    		if (!behavior.isRoutedEventHandlerAssign)
    		{
    			item.PasswordChanged += (sender, eArg) =>
    			{
    				behavior.Text = item.Password;
    			};
    			behavior.isRoutedEventHandlerAssign = true;
    		}
    	}
    
    	public PasswordBoxBehavior()
    	{
    	}
    }
