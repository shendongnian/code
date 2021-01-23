	public class MyButton : System.Windows.Forms.Button
	{
		public bool ShouldSerializeImage()
		{
			return !object.ReferenceEquals(this.Image, _BaseImage);
		}
		public void ResetImage()
		{
			this.Image = _BaseImage;
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		public new Image Image
		{
			get { return base.Image; }
			set { base.Image = value; }
		}
		private Bitmap _BaseImage;
		public MyButton()
		{
			_BaseImage = Proyecto.Controls.Bases.Properties.Resources.ok_16;
			this.Image = _BaseImage;
		}
	}
