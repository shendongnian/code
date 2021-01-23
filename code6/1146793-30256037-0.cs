    public class MySpecialGrid : Control
    {
        ctor() {
            DefaultStyleKey = typeof(MySpecialGrid);
            Columns = new RadGridViewColumnsConfiguration();
        }
        public RadGridViewColumnsConfiguration Columns
		{
			get { return (RadGridViewColumnsConfiguration) GetValue( ColumnsProperty ); }
			set { SetValue( ColumnsProperty, value ); }
		}
		public static readonly DependencyProperty ColumnsProperty =
			DependencyProperty.Register( "Columns", typeof( RadGridViewColumnsConfiguration),
            typeof( MySpecialGrid), null );
    }
