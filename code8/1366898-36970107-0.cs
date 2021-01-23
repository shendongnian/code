    	public Modelis MyModelis
		{
			get { return (Modelis)GetValue(MyModelisProperty); }
			set { SetValue(MyModelisProperty, value); }
		}
		// Using a DependencyProperty as the backing store for MyModelis.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MyModelisProperty =
			DependencyProperty.Register("MyModelis", typeof(Modelis), typeof(Window1), new PropertyMetadata(new Modelis(DialogCoordinator.Instance)));
