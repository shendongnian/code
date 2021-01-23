    [TypeConverter(typeof(ExpandableObjectConverter))]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public class Einstellungen
	{
		[Category("My Category")]
		[Description("My Description")]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public bool CanGroup { get; set; }
		[Category("My Category")]
		[Description("My Description")]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public bool IsEditable { get; set; }
	}
