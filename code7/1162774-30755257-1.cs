    public class OuterControl : Control
	{
		public OuterControl()
		{
			DefaultStyleKey = typeof( OuterControl );
		}
		public InnerControl Content
		{
			get { return (InnerControl) GetValue( ContentProperty ); }
			set { SetValue( ContentProperty, value ); }
		}
		public static readonly DependencyProperty ContentProperty =
			DependencyProperty.Register( "Content", typeof( InnerControl ), typeof( OuterControl ), new PropertyMetadata( null ) );
		
		public DataTemplate ContentTemplate
		{
			get { return (DataTemplate) GetValue( ContentTemplateProperty ); }
			set { SetValue( ContentTemplateProperty, value ); }
		}
		public static readonly DependencyProperty ContentTemplateProperty =
			DependencyProperty.Register( "ContentTemplate", typeof( DataTemplate ), typeof( OuterControl ), new PropertyMetadata( null ) );
	}
