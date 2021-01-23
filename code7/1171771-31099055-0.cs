    //You simplified model
	    public class bModel : BindableObject
	    {
		    private Color _realColor;
		    public  Color Color 
		    { 
			    get { return _realColor; } 
			    set 
			    { 	
				    _realColor = value;
				    OnPropertyChanged ("Color"); 
			    }
		    }
		    public string _stringColor;
		    public string StringColor {
			    get {
				    return _stringColor;
			    }
			    set {
				    _stringColor = value;
	   			    Color = (Color)(new ColorTypeConverter ()).ConvertFrom (_stringColor);
			    }
		    }
		    public bModel ()
		    {
			    StringColor = "Blue";
		    }
	    }
    }
    //Your simplified page xaml
    <?xml version="1.0" encoding="UTF-8"?>
    <ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="s2c.MyPage">
	    <ContentPage.Content>
		    <BoxView x:Name="box" Color="{Binding Color}"/>
	    </ContentPage.Content>
    </ContentPage>
    //Your simplified page csharp
    public partial class MyPage : ContentPage
	{
		public MyPage ()
		{
			InitializeComponent ();
			this.BindingContext = new bModel ();
		}
	}
