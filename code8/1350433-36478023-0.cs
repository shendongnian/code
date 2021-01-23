	/// <summary>
	/// Add a new string to the current page
	/// </summary>
	/// <param name="text">The string to print</param>
	/// <param name="align">Optional alignment of the string</param>
	public void DrawString(string text, System.Windows.TextAlignment align = System.Windows.TextAlignment.Left, int MaxWidth = -1 ) {
		RectangleF textBounds;
		SolidBrush brush = new SolidBrush( ForeColor );
		StringFormat sf = ConvertAlignment(align);
		LineBreaker lines = breakIntoLines(text, MaxWidth);
		int currentLine = 1;
		int originX = X;
		foreach ( string line in lines.Lines ) {
			// add string to document
			using ( Graphics g=Graphics.FromImage( Pages[CurrentPage - 1] ) ) {
				g.CompositingQuality = CompositingQuality.HighQuality;
				textBounds=new RectangleF( X, Y, lines.MaxWidthPixels, lines.StringHeight );
				if ( align==System.Windows.TextAlignment.Justify ) {
					if ( currentLine<lines.Lines.Count ) {
						string lastword=line.Split( ' ' ).Last();
						if ( line.Contains( ' ' ) ) {
							// routine to caclulate how much padding is needed and apply the extra spaces as evenly as possibly by looping
							// through the words. it starts at the first word adding a space after if needed and then continues through the
							// remaining words adding a space before them as needed and excludes the right most word which is printed as right
							// align always.
							string lineNoLastWord=line.Substring( 0, line.LastIndexOf( " " ) ).Trim();
							List<string> words=lineNoLastWord.Split( ' ' ).ToList<string>();
							int lastwordwidth=(Int32)g.MeasureString( " "+lastword, Font ).Width;
							int extraspace=lines.MaxWidthPixels-(Int32)( g.MeasureString( " "+lineNoLastWord, Font ).Width+lastwordwidth );
							int totalspacesneeded=(Int32)Math.Ceiling( (decimal)extraspace/(decimal)lines.SpaceWidth );
							int spacecount=lineNoLastWord.Count( x => x==' ' );
							int currentwordspace=0;
							if ( words.Count>1 ) {
								while ( totalspacesneeded>0 ) {
									if ( currentwordspace>spacecount ) { currentwordspace=0; }
									// insert spaces where spaces already exist between each word
									// use currentwordspace to determine which word to replace with a word and another space
									if ( currentwordspace==0 ) {
										// insert space after word
										words[currentwordspace]+=" ";
									} else {
										// insert space before word
										words[currentwordspace]=" "+words[currentwordspace];
									}
									currentwordspace++;
									totalspacesneeded--;
									if ( totalspacesneeded==0 ) { break; }
								}
							}
							lineNoLastWord=String.Join( " ", words );
							g.DrawString( lineNoLastWord, Font, brush, textBounds, sf );
							g.DrawString( lastword, Font, brush, textBounds, ConvertAlignment( System.Windows.TextAlignment.Right ) );
						} else {
							// when only 1 word, just draw it
							g.DrawString( line, Font, brush, textBounds, ConvertAlignment( System.Windows.TextAlignment.Left ) );
						}
					} else {
						// just draw the last line
						g.DrawString( line, Font, brush, textBounds, ConvertAlignment( System.Windows.TextAlignment.Left ) );
					}
				} else {
					g.DrawString( line, Font, brush, textBounds, sf );
				}
			}
			Y+=lines.LineHeight;
			if ( Y+lines.LineHeight>Pages[CurrentPage-1].Height ) {
				NewPage();
				if ( currentLine<lines.Lines.Count ) { X=originX; }
			}
			currentLine++;
		}
	}
	/// <summary>
	/// Break a long string into multiple lines. Is also carriage return aware.
	/// </summary>
	/// <param name="s">the string</param>
	/// <param name="maxLineWidth">the maximum width of the rectangle. if -1, will use the full width of the image</param>
	/// <returns></returns>
	internal LineBreaker breakIntoLines( string s, int maxLineWidth ) {
		List<string> sResults = new List<string>();
		int stringHeight;
		int lineHeight;
		int maxWidthPixels = maxLineWidth;
		int spaceWidth;
		string[] lines = s.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.None);
		using ( Graphics g=Graphics.FromImage( Pages[CurrentPage - 1] ) ) {
			g.CompositingQuality = CompositingQuality.HighQuality;
			if ( maxLineWidth<=0||maxLineWidth>( Pages[CurrentPage-1].Width-X ) ) {
				maxWidthPixels=Pages[CurrentPage-1].Width-X;
			}
			lineHeight = (Int32)( g.MeasureString( "X", Font ).Height*(float)( (float)LineSpacing/(float)100 ) );
			stringHeight = (Int32)g.MeasureString( "X", Font ).Height;
			spaceWidth=(Int32)g.MeasureString( " ", Font ).Width;
			foreach ( string line in lines ) {
				string[] words=line.Split( new string[] { " " }, StringSplitOptions.None );
				sResults.Add( "" );
				for ( int i=0; i<words.Length; i++ ) {
					if ( sResults[sResults.Count-1].Length==0 ) {
						sResults[sResults.Count-1]=words[i];
					} else {
						if ( g.MeasureString( sResults[sResults.Count-1]+" "+words[i], Font ).Width<maxWidthPixels ) {
							sResults[sResults.Count-1]+=" "+words[i];
						} else {
							sResults.Add( words[i] );
						}
					}
				}
			}
		}
		return new LineBreaker() {
			LineHeight = lineHeight,
			StringHeight = stringHeight,
			MaxWidthPixels = maxWidthPixels,
			Lines = sResults,
			SpaceWidth = spaceWidth
		};
	}
	/// <summary>
	/// Helper method to convert TextAlignment to StringFormat
	/// </summary>
	/// <param name="align">System.Windows.TextAlignment</param>
	/// <returns>System.Drawing.StringFormat</returns>
	private StringFormat ConvertAlignment(System.Windows.TextAlignment align) {
		StringFormat s = new StringFormat();
		switch ( align ) {
			case System.Windows.TextAlignment.Left:
			case System.Windows.TextAlignment.Justify:
				s.LineAlignment=StringAlignment.Near;
				break;
			case System.Windows.TextAlignment.Right:
				s.LineAlignment=StringAlignment.Far;
				break;
			case System.Windows.TextAlignment.Center:
				s.LineAlignment=StringAlignment.Center;
				break;
		}
		s.Alignment = s.LineAlignment;
		return s;
	}
	/// <summary>
	/// Class to hold the line data after broken up and measured using breakIntoLines()
	/// </summary>
	internal class LineBreaker {
		public List<string> Lines { get; set; }
		public int MaxWidthPixels { get; set; }
		public int StringHeight { get; set; }
		public int LineHeight { get; set; }
		public int SpaceWidth { get; set; }
		public LineBreaker() {
			Lines = new List<string>();
			MaxWidthPixels = 0;
			StringHeight = 0;
			LineHeight = 0;
			SpaceWidth = 0;
		}
		public LineBreaker( List<string> lines, int maxWidthPixels, int stringHeight, int lineHeight, int spaceWidth ) {
			Lines = lines;
			MaxWidthPixels = maxWidthPixels;
			LineHeight = lineHeight;
			StringHeight = stringHeight;
			SpaceWidth = spaceWidth;
		}
	}
