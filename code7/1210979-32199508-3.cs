	public class Annotation
	{
		public Annotation(int pos, int x2, int y2, string artNr)
		{
			this.ArtNr = artNr;
			this.Pos = pos;
			this.X2 = x2;
			this.Y2 = y2;
		}
		
		public string ArtNr { get; private set; }
		public int Pos { get; private set; }
		public int X2 { get; private set; }
		public int Y2 { get; private set; }
	}
	
