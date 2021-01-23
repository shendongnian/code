	using System.Drawing;
	using System.Drawing.Printing;
	namespace PrintingFromConsole
	{
		class Program
		{
			static void Main(string[] args)
			{
				PrintDocument doc = new PrintDocument();
				doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
				doc.Print();
			}
			private static void doc_PrintPage(object sender, PrintPageEventArgs e)
			{
				e.Graphics.DrawString("text", SystemFonts.DefaultFont, Brushes.Black, new PointF(100f, 100f));
				e.HasMorePages = false;
			}
		}
	}
