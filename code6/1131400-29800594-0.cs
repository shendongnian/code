	public partial class ColorDefiner : UserControl {
		private event EventHandler<Color> ColorChangedEvent;
		public event EventHandler<Color> ColorChanged{
			add{this.ColorChangedEvent += value;}
			remove{this.ColorChangedEvent -= value;}
		}
		#region Dependency Properties
		public static readonly DependencyProperty
			ColorProperty = DependencyProperty.Register( "Color", typeof( Color ), typeof( ColorDefiner ), new FrameworkPropertyMetadata(
				Colors.Black, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, ColorDefiner.OnColorPropertyChanged ) );
		private static void OnColorPropertyChanged( DependencyObject d, DependencyPropertyChangedEventArgs e ) {
			ColorDefiner CD = d as ColorDefiner;
			if ( CD.ColorChangedEvent != null )
				CD.ColorChangedEvent( CD, (Color)e.NewValue );
		}
		#endregion
