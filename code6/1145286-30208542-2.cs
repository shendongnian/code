    public class StringMultiplexer : DependencyObject
	{
		public string LowPrioString
		{
			get { return (string) GetValue( LowPrioStringProperty ); }
			set { SetValue( LowPrioStringProperty, value ); }
		}
		public static readonly DependencyProperty LowPrioStringProperty =
			DependencyProperty.Register( "LowPrioString", typeof( string ), typeof( StringMultiplexer ), new PropertyMetadata( DetermineOutput ) );
		public string HighPrioString
		{
			get { return (string) GetValue( HighPrioStringProperty ); }
			set { SetValue( HighPrioStringProperty, value ); }
		}
		public static readonly DependencyProperty HighPrioStringProperty =
			DependencyProperty.Register( "HighPrioString", typeof( string ), typeof( StringMultiplexer ), new PropertyMetadata( DetermineOutput ) );
		public string Output
		{
			get { return (string) GetValue( OutputProperty ); }
			set { SetValue( OutputProperty, value ); }
		}
		public static readonly DependencyProperty OutputProperty =
			DependencyProperty.Register( "Output", typeof( string ), typeof( StringMultiplexer ), null );
		private static void DetermineOutput( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			((StringMultiplexer) d).DetermineOutput();
		}
		private void DetermineOutput()
		{
			Output = (string.IsNullOrEmpty( HighPrioString )) ? LowPrioString : HighPrioString;
		}
	}
