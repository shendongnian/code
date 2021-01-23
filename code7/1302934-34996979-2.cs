	public bool ShouldSerializeImage()
	{
		return !object.ReferenceEquals(this.Image, Proyecto.Controls.Bases.Properties.Resources.ok_16);
	}
	public void ResetImage()
	{
		this.Image = Proyecto.Controls.Bases.Properties.Resources.ok_16;
	}
	
	[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
	public new Image Image {
		get { return base.Image; }
		set { base.Image = value; }
	}
