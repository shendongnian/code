	public class MyTabControl : TabControl
	{
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(true)]
		public new int SelectedIndex
		{
			get { return base.SelectedIndex; }
			set { base.SelectedIndex = value; }
		}
	}
