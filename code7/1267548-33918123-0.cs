	class MyExtension
	{
		protected Control control;
		public MyExtension(Control control)
		{
			this.control = control;
		}
		
		public object Property1 { get; set; }
		public object Property2 { get; set; }
		public void MakeInvisible()
		{
			this.control.Visible = false;
		}
	}
	class MyButton : MyExtension
	{
		public MyButton(Button button):base(button){}
		public int ButtonProperty { get; set; }
	}
	class MyLabel : Label
	{
		public MyButton(Label label):base(label){}
		public bool LabelProperty { get; set; }
	}
