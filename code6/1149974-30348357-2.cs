    [StyleTypedProperty( Property = "ToggleButtonStyle", StyleTargetType = typeof( ToggleButton ) )]
	[StyleTypedProperty( Property = "DropDownBackgroundStyle", StyleTargetType = typeof( Border ) )]
    public class DropDownButton : Control
	{
	    ...
		
		public Style ToggleButtonStyle
		{
			get { return (Style) GetValue( ToggleButtonStyleProperty ); }
			set { SetValue( ToggleButtonStyleProperty, value ); }
		}
		public static readonly DependencyProperty ToggleButtonStyleProperty =
			DependencyProperty.Register( "ToggleButtonStyle", typeof( Style ), typeof( DropDownButton ), null );
			
		public Style DropDownBackgroundStyle
		{
			get { return (Style) GetValue( DropDownBackgroundStyleProperty ); }
			set { SetValue( DropDownBackgroundStyleProperty, value ); }
		}
		public static readonly DependencyProperty DropDownBackgroundStyleProperty =
			DependencyProperty.Register( "DropDownBackgroundStyle", typeof( Style ), typeof( DropDownButton ), null );
		
	}
