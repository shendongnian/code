    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
    	"Text", typeof(string), typeof(WatermarkTextBox),
    	new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
    		(s, e) => ((WatermarkTextBox)s).OnTextChanged((string)e.OldValue, (string)e.NewValue))
    );
    
    public string Text {
    	get { return (string)this.GetValue(TextProperty); }
    	set { this.SetValue(TextProperty, value); }
    }
    
    void OnTextChanged(string oldValue, string newValue) { 
    	//....
    }
