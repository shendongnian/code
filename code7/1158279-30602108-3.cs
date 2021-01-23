    public partial class CustomButton : Button
    {
    
    	#region IconAutomationId
    
    	public string IconAutomationId
    	{
    		get { return (string)GetValue(IconAutomationIdProperty); }
    		set { SetValue(IconAutomationIdProperty, value); }
    	}
    
    	public static readonly DependencyProperty IconAutomationIdProperty =
    		DependencyProperty.Register("IconAutomationId", typeof(string), typeof(CustomButton), new PropertyMetadata(null));
    	
    	#endregion
    
    	#region LabelAutomationId
    
    	public string LabelAutomationId
    	{
    		get { return (string)GetValue(LabelAutomationIdProperty); }
    		set { SetValue(LabelAutomationIdProperty, value); }
    	}
    
    	public static readonly DependencyProperty LabelAutomationIdProperty =
    		DependencyProperty.Register("LabelAutomationId", typeof(string), typeof(CustomButton), new PropertyMetadata(null));
    	
    	#endregion
    
    	#region TextAutomationId
    
    	public string TextAutomationId
    	{
    		get { return (string)GetValue(TextAutomationIdProperty); }
    		set { SetValue(TextAutomationIdProperty, value); }
    	}
    
    	public static readonly DependencyProperty TextAutomationIdProperty =
    		DependencyProperty.Register("TextAutomationId", typeof(string), typeof(CustomButton), new PropertyMetadata(null));
    	
    	#endregion
    
    	#region Symbol
    
    	public object Symbol
    	{
    		get { return (object)GetValue(SymbolProperty); }
    		set { SetValue(SymbolProperty, value); }
    	}
    
    	public static readonly DependencyProperty SymbolProperty =
    		DependencyProperty.Register("Symbol", typeof(object), typeof(CustomButton), new PropertyMetadata(null));
    	
    	#endregion
    
    	#region Label
    
    	public string Label
    	{
    		get { return (string)GetValue(LabelProperty); }
    		set { SetValue(LabelProperty, value); }
    	}
    
    	public static readonly DependencyProperty LabelProperty =
    		DependencyProperty.Register("Label", typeof(string), typeof(CustomButton), new PropertyMetadata(null));
    	
    	#endregion
    
    	#region Text
    
    	public string Text
    	{
    		get { return (string)GetValue(TextProperty); }
    		set { SetValue(TextProperty, value); }
    	}
    
    	public static readonly DependencyProperty TextProperty =
    		DependencyProperty.Register("Text", typeof(string), typeof(CustomButton), new PropertyMetadata(null));
    	
    	#endregion
    
    	public CustomButton()
    	{
    		InitializeComponent();
    	}
    }
