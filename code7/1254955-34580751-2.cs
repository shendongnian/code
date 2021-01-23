    public class MyBehavior : Behavior
	{
		private static readonly ToolTip ToolTip = new ToolTip
		{
			ToolTipTitle = "UI guide line issues found",
			ToolTipIcon = ToolTipIcon.Warning
		};
		public override bool OnMouseEnter(Glyph g)
		{
			VolkerIssueGlyph glyph = (VolkerIssueGlyph)g;
			if (!glyph.Control.Visible) return false;
			lock(ToolTip)
			    ToolTip.Show(GetText(glyph), glyph.Control, glyph.Control.PointToClient(Control.MousePosition), 2000);
			return true;
		}
		public override bool OnMouseLeave(Glyph g)
		{
		    lock (ToolTip)
				ToolTip.Hide(((VolkerIssueGlyph)g).Control);
			return true;
		}
		private static string GetText(VolkerIssueGlyph glyph)
		{
			return string.Format("{0} has {1} conflicts!", glyph.Control.Name, glyph.Issues);
		}
	}
