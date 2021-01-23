    public partial class KeyValueView : ContentView
    {
    	public KeyValueView()
    	{
    		InitializeComponent();
    		this.VerticalOptions = LayoutOptions.Start;
    	}
    
    	public static readonly BindableProperty ValueProperty =
    		BindableProperty.Create<KeyValueView, string>(w => w.Value, default(string));
    
    	public string Value
    	{
    		get {return (string)GetValue(ValueProperty);}
    		set {SetValue(ValueProperty, value);}
    	}
    
    	public static readonly BindableProperty KeyProperty =
    		BindableProperty.Create<KeyValueView, string>(w => w.Key, default(string));
    
    	public string Key
    	{
    		get {return (string)GetValue(KeyProperty);}
    		set {SetValue(KeyProperty, value);}
    	}
    	protected override void OnPropertyChanged(string propertyName)
    	{
    		base.OnPropertyChanged(propertyName);
    
    		if (propertyName == ValueProperty.PropertyName)
    		{
    			ValueLabel.Text = Value;
    		}
    		if (propertyName == KeyProperty.PropertyName)
    		{
    			KeyLabel.Text = Key;
    		}
    	}
    }
    <ContentView xmlns="http://xamarin.com/schemas/2014/forms"
                 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                 x:Class="KeyValueView">
        <Grid VerticalOptions="Start">
            <Grid.ColumnDefinitions>
                <ColumnDefinition />
                <ColumnDefinition />
            </Grid.ColumnDefinitions>
    
            <Label x:Name="KeyLabel" Grid.Column="0" HorizontalOptions="Start" />
            <Label x:Name="ValueLabel" Grid.Column="1" HorizontalOptions="EndAndExpand" />
        </Grid>
    </ContentView>
