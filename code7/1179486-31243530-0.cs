	public abstract class DispBase
	{
		public abstract Brush BackgroundBrush { get; set; }
	}
	public class Element : DispBase
	{
		[XmlIgnore]
		[Browsable(false)]
		public override Brush BackgroundBrush { get; set; }
	}
	public class Display : DispBase
	{
		public override Brush BackgroundBrush { get; set; }
	}
