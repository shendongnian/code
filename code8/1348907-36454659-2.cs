	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Drawing;
	using System.Drawing.Drawing2D;
	using System.Windows.Forms;
	using System.Windows.Forms.Design;
	using System.Drawing.Printing;
	using System.ComponentModel;
	using System.IO;
	class PDF : PrintDocument {
		/// <summary>
		/// Logo to display on invoice
		/// </summary>
		public Image Logo { get; set; }
		/// <summary>
		/// Current X position on canvas
		/// </summary>
		public int X { get; set; }
		/// <summary>
		/// Current Y position on canvas
		/// </summary>
		public int Y { get; set; }
		/// <summary>
		/// Set the folder where backups, downloads, etc will be stored or retrieved from
		/// </summary>
		[Editor( typeof( System.Windows.Forms.Design.FolderNameEditor ), typeof( System.Drawing.Design.UITypeEditor ) )]
		public string Folder { get { return directory; } set { directory=value; } }
		/// <summary>
		/// Current font used to print
		/// </summary>
		public Font Font { get; set; }
		/// <summary>
		/// Current font color
		/// </summary>
		public Color ForeColor { get; set; }
		private int CurrentPagePrinting { get; set; }
		/// <summary>
		/// Set printer margins
		/// </summary>
		public Margins PrintMargins {
			get { return DefaultPageSettings.Margins; }
			set { DefaultPageSettings.Margins = value; }
		}
		/// <summary>
		/// Pages drawn in document
		/// </summary>
		public List<Image> Pages { get; private set; }
		/// <summary>
		/// The current selected page number. 0 if nothing selected
		/// </summary>
		private int CurrentPage;
		/// <summary>
		/// The current working directory to save files to
		/// </summary>
		private string directory;
		/// <summary>
		/// The currently chosen filename
		/// </summary>
		private string file;
		/// <summary>
		/// Public acceisble object to all paperSizes as set
		/// </summary>
		public List<PrintPaperSize> PaperSizes { get; private set; }
		/// <summary>
		/// Object for holding papersizes
		/// </summary>
		public class PrintPaperSize {
			public string Name { get; set; }
			public double Height { get; set; }
			public double Width { get; set; }
			public PaperKind Kind { get; set; }
			public PrintPaperSize() {
				Height = 0;
				Width = 0;
				Name = "";
				Kind = PaperKind.Letter;
			}
			public PrintPaperSize( string name, double height, double width, PaperKind kind ) {
				Height=height;
				Width=width;
				Name=name;
				Kind=kind;
			}
		}
		/// <summary>
		/// Set the spacing between lines in percentage. Affects Y position. Range(%): 1 - 1000
		/// </summary>
		private int lineSpacing;
		public int LineSpacing {
			get {
				return lineSpacing;
			}
			set {
				if(value > 0 && value < 1000) {
					lineSpacing = value;
				}
			}
		}
		/// <summary>
		/// Current papersize selected. used for some calculations
		/// </summary>
		public PrintPaperSize CurrentPaperSize { get; private set; }
		public PDF() {
			// set the file name without extension to something safe
			file = (string)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds.ToString();
			// set the save directory to MyDocuments
			directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			CurrentPage = 0;
			// initialize pages array
			Pages = new List<Image>();
			// Set the initial font and color
			Font = new System.Drawing.Font("Arial", (float)11.25, FontStyle.Regular, GraphicsUnit.Point);
			ForeColor = Color.Black;
			lineSpacing = 100;
			// set the printer to Microsoft's PDF printer and generate and ensure it will save to a file
			PrinterSettings = new PrinterSettings() {
				PrinterName = "Microsoft Print to PDF",
				PrintToFile = true,
				PrintFileName = Path.Combine(directory, file + ".pdf"),
			};
			// hide the notice 'printing' while spooling job.
			PrintController = new StandardPrintController();
			// set the printer quality to maximum so we can use this for getting the dpi at this setting
			DefaultPageSettings.PrinterResolution.Kind = PrinterResolutionKind.High;
			// store all paper sizes at 1 dpi [ reference: https://social.msdn.microsoft.com/Forums/vstudio/en-US/05169a47-04d5-4890-9b0a-7ad11a6a87f2/need-pixel-width-for-paper-sizes-a4-a5-executive-letter-legal-executive?forum=csharpgeneral ]
			PaperSizes = new List<PrintPaperSize>();
			foreach ( PaperSize P in PrinterSettings.PaperSizes ) {
				double W=P.Width/100.0;
				double H=P.Height/100.0;
				PaperSizes.Add(
					new PrintPaperSize() {
						Height = H,
						Width = W,
						Name = P.PaperName,
						Kind = P.Kind
					}
				);
				if ( P.PaperName=="Letter" ) {
					CurrentPaperSize = PaperSizes[PaperSizes.Count-1];
				}
			}
			// setup the initial page type, orientation, margins, 
			using ( Graphics g=PrinterSettings.CreateMeasurementGraphics() ) {
				DefaultPageSettings = new PageSettings(PrinterSettings) {
					PaperSize=new PaperSize( CurrentPaperSize.Name, (Int32)(CurrentPaperSize.Width*g.DpiX), (Int32)(CurrentPaperSize.Height*g.DpiY) ),
					Landscape = false,
					Margins = new Margins(left: 100, right: 100, top: 10, bottom: 10),
					PrinterResolution=new PrinterResolution() {
						Kind = PrinterResolutionKind.High
					}
				};
			}
			// constrain print within margins
			OriginAtMargins = false;
		}
		public void SetPaperSize( PaperKind paperSize ) {
			// TODO: Use Linq on paperSizes
		}
		/// <summary>
		/// Get specific page
		/// </summary>
		/// <param name="page">page number. 1 based array</param>
		/// <returns></returns>
		public Image GetPage( int page ) {
			int p = page - 1;
			if ( p<0||p>Pages.Count ) { return null; }
			return Pages[p];
		}
		/// <summary>
		/// Get the current page
		/// </summary>
		/// <returns>Image</returns>
		 public Image GetCurrentPage() {
			return GetPage(CurrentPage);
		}
		/// <summary>
		/// Before printing starts
		/// </summary>
		/// <param name="e">PrintEventArgs</param>
		protected override void OnBeginPrint( PrintEventArgs e ) {
			 CurrentPagePrinting=0;
			 base.OnBeginPrint( e );
		}
		/// <summary>
		/// Print page event
		/// </summary>
		/// <param name="e">PrintPageEventArgs</param>
		protected override void OnPrintPage( PrintPageEventArgs e ) {
			CurrentPagePrinting++;
			// if page count is max exit print routine
			if ( CurrentPagePrinting==Pages.Count ) { e.HasMorePages=false; } else { e.HasMorePages=true; }
			// ensure high resolution / clarity of image so text doesn't fuzz
			e.Graphics.CompositingMode=CompositingMode.SourceOver;
			e.Graphics.CompositingQuality=CompositingQuality.HighQuality;
			// Draw image and respect margins (unscaled in addition to the above so text doesn't fuzz)
			e.Graphics.DrawImageUnscaled(
				Pages[CurrentPagePrinting-1],
	//			new Point(0,0)
				new Point(
					DefaultPageSettings.Margins.Left,
					DefaultPageSettings.Margins.Top
				)
			);
			base.OnPrintPage( e );
		}
		/// <summary>
		/// After printing has been completed
		/// </summary>
		/// <param name="e">PrintEventArgs</param>
		protected override void OnEndPrint( PrintEventArgs e ) {
			base.OnEndPrint( e );
		}
		/// <summary>
		/// Add a new page to the document
		/// </summary>
		public void NewPage() {
			// Add a new page to the page collection and set it as the current page
			Bitmap bmp;
			using(Graphics g = PrinterSettings.CreateMeasurementGraphics()) {
				int w=(Int32)( CurrentPaperSize.Width*g.DpiX )-(Int32)( ( ( DefaultPageSettings.Margins.Left+DefaultPageSettings.Margins.Right )/100 )*g.DpiX );
				int h=(Int32)( CurrentPaperSize.Height*g.DpiY )-(Int32)( ( ( DefaultPageSettings.Margins.Top+DefaultPageSettings.Margins.Bottom )/100 )*g.DpiY );
				bmp = new Bitmap( w, h );
				bmp.SetResolution(g.DpiX, g.DpiY);
			}
			// reset X and Y positions
			Y=0;
			X=0;
			// Add new page to the collection
			Pages.Add( bmp );
			CurrentPage++;
		}
		/// <summary>
		/// Change the current page to specified page number
		/// </summary>
		/// <param name="page">page number</param>
		/// <returns>true if page change was successful</returns>
		public bool SetCurrentPage( int page ) {
			if ( page<1 ) { return false; }
			if ( page>Pages.Count ) { return false; }
		    CurrentPage = page - 1;
		    return true;
		}
		/// <summary>
		/// Remove the specified page #
		/// </summary>
		/// <param name="page">page number</param>
		/// <returns>true if successful</returns>
		public bool RemovePage(int page) {
			if ( page<1 ) { return false; }
			if ( page>Pages.Count ) { return false; }
			if ( Pages.Count-page==0 ) {
				CurrentPage = 0;
				Pages.RemoveAt(page - 1);
			} else {
				if ( page==CurrentPage && CurrentPage == 1 ) {
					Pages.RemoveAt(page - 1);
				} else {
					CurrentPage = CurrentPage - 1;
					Pages.RemoveAt(page -1);
				}
			}
			return true;
		}
		/// <summary>
		/// Add a new string to the current page
		/// </summary>
		/// <param name="text">The string to print</param>
		/// <param name="align">Optional alignment of the string</param>
		public void DrawString(string text, System.Windows.TextAlignment align = System.Windows.TextAlignment.Left ) {
			// add string to document
			using ( Graphics g=Graphics.FromImage( Pages[CurrentPage - 1] ) ) {
				g.CompositingQuality = CompositingQuality.HighQuality;
				// get linespacing and adjust by user specified linespacing
				int iLineSpacing=(Int32)( g.MeasureString( "X", Font ).Height*(float)( (float)LineSpacing/(float)100 ) );
				switch ( align ) {
					case System.Windows.TextAlignment.Left:
					case System.Windows.TextAlignment.Justify:
						g.DrawString( text, Font, new SolidBrush( ForeColor ), new PointF( X, Y ) );
						break;
					case System.Windows.TextAlignment.Right:
						g.DrawString( text, Font, new SolidBrush( ForeColor ), new PointF( Pages[CurrentPage - 1].Width - g.MeasureString( text, Font ).Width, Y ) );
						break;
					case System.Windows.TextAlignment.Center:
						g.DrawString( text, Font, new SolidBrush( ForeColor ), new PointF( ( Pages[CurrentPage-1].Width+g.MeasureString( text, Font ).Width )/2, Y ) );
						break;
				}
				Y+=iLineSpacing;
				if( Y + iLineSpacing > Pages[CurrentPage-1].Height ) {
					NewPage();
				}
			}
		}
	}
