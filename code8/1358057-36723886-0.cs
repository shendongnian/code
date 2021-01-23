    class FixedButton : Button {
		public string FixedText;
		public Point TextOffset;
		public PointF FixedTextLocation {
			get{return new PointF( (float)(Location.X+TextOffset.X), (float)(Location.Y+TextOffset.Y) );}
		}
		
		protected override void OnPaint(PaintEventArgs e){
			base.OnPaint(e);
			
			if(String.IsNullOrEmpty(Text) && !String.IsNullOrEmpty(FixedText) ){
				e.Graphics.DrawString(FixedText, Font, new SolidBrush(ForeColor), FixedTextLocation);
			}
		}
	}
