    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    
    // how to highlight a text or word in a pdf file using iTextsharp?
    // https://stackoverflow.com/questions/6523243/how-to-highlight-a-text-or-word-in-a-pdf-file-using-itextsharp
    //
    // myLocationTextExtractionStrategy has been shared by Jcis in his answer
    // https://stackoverflow.com/a/11076968/1729265
    // as VB class. This has been translated to C# using Telerik with some minor
    // translation glitch fixes.
    namespace iTextSharp_Playground.Content
    {
    	public class myLocationTextExtractionStrategy : ITextExtractionStrategy
    	{
            private float _UndercontentCharacterSpacing = 0;
            private float _UndercontentHorizontalScaling = 0;
    
    		private SortedList<string, DocumentFont> ThisPdfDocFonts;
    
    		public static bool DUMP_STATE = false;
    		//* a summary of all found text 
    
    		private List<TextChunk> locationalResult = new List<TextChunk>();
    		//*
    		//         * Creates a new text extraction renderer.
    		//         
    
    		public myLocationTextExtractionStrategy()
    		{
    			ThisPdfDocFonts = new SortedList<string, DocumentFont>();
    		}
    
    		//*
    		//         * @see com.itextpdf.text.pdf.parser.RenderListener#beginTextBlock()
    		//         
    
    		public virtual void BeginTextBlock()
    		{
    		}
    
    		//*
    		//         * @see com.itextpdf.text.pdf.parser.RenderListener#endTextBlock()
    		//         
    
    		public virtual void EndTextBlock()
    		{
    		}
    
    		//*
    		//         * @param str
    		//         * @return true if the string starts with a space character, false if the string is empty or starts with a non-space character
    		//         
    
    		private bool StartsWithSpace(String str)
    		{
    			if (str.Length == 0) {
    				return false;
    			}
    			return str[0] == ' ';
    		}
    
    		//*
    		//         * @param str
    		//         * @return true if the string ends with a space character, false if the string is empty or ends with a non-space character
    		//         
    
    		private bool EndsWithSpace(String str)
    		{
    			if (str.Length == 0) {
    				return false;
    			}
    			return str[str.Length - 1] == ' ';
    		}
    
    		public float UndercontentCharacterSpacing {
    			get { return _UndercontentCharacterSpacing; }
    			set { _UndercontentCharacterSpacing = value; }
    		}
    
            public float UndercontentHorizontalScaling
            {
    			get { return _UndercontentHorizontalScaling; }
    			set { _UndercontentHorizontalScaling = value; }
    		}
    
    		public virtual String GetResultantText()
    		{
    
    			if (DUMP_STATE) {
    				DumpState();
    			}
    
    			locationalResult.Sort();
    
    			StringBuilder sb = new StringBuilder();
    			TextChunk lastChunk = null;
    
    			foreach (TextChunk chunk in locationalResult) {
    				if (lastChunk == null) {
    					sb.Append(chunk.text);
    				} else {
    					if (chunk.SameLine(lastChunk)) {
    						float dist = chunk.DistanceFromEndOf(lastChunk);
    						if (dist < -chunk.charSpaceWidth) {
    							sb.Append(' ');
    							// we only insert a blank space if the trailing character of the previous string wasn't a space, and the leading character of the current string isn't a space
    						} else if (dist > chunk.charSpaceWidth / 2f && !StartsWithSpace(chunk.text) && !EndsWithSpace(lastChunk.text)) {
    							sb.Append(' ');
    						}
    
    						sb.Append(chunk.text);
    					} else {
    						sb.Append((char)10);
    						sb.Append(chunk.text);
    					}
    				}
    				lastChunk = chunk;
    			}
    
    			return sb.ToString();
    
    		}
    
    		public List<iTextSharp.text.Rectangle> GetTextLocations(string pSearchString, System.StringComparison pStrComp)
    		{
    			List<iTextSharp.text.Rectangle> FoundMatches = new List<iTextSharp.text.Rectangle>();
    			StringBuilder sb = new StringBuilder();
    			List<TextChunk> ThisLineChunks = new List<TextChunk>();
    			bool bStart = false;
    			bool bEnd = false;
    			TextChunk FirstChunk = null;
    			TextChunk LastChunk = null;
    			string sTextInUsedChunks = null;
    
    			foreach (TextChunk chunk in locationalResult) {
                    if (ThisLineChunks.Count > 0 && !chunk.SameLine(ThisLineChunks[ThisLineChunks.Count-1]))
                    {
    					if (sb.ToString().IndexOf(pSearchString, pStrComp) > -1) {
    						string sLine = sb.ToString();
    
    						//Check how many times the Search String is present in this line:
    						int iCount = 0;
    						int lPos = 0;
    						lPos = sLine.IndexOf(pSearchString, 0, pStrComp);
    						while (lPos > -1) {
    							iCount += 1;
    							if (lPos + pSearchString.Length > sLine.Length)
    								break; // TODO: might not be correct. Was : Exit Do
    
    							else
    								lPos = lPos + pSearchString.Length;
    							lPos = sLine.IndexOf(pSearchString, lPos, pStrComp);
    						}
    
    						//Process each match found in this Text line:
    						int curPos = 0;
    						for (int i = 1; i <= iCount; i++) {
    							string sCurrentText = null;
    							int iFromChar = 0;
    							int iToChar = 0;
    
    							iFromChar = sLine.IndexOf(pSearchString, curPos, pStrComp);
    							curPos = iFromChar;
    							iToChar = iFromChar + pSearchString.Length - 1;
    							sCurrentText = null;
    							sTextInUsedChunks = null;
    							FirstChunk = null;
    							LastChunk = null;
    
    							//Get first and last Chunks corresponding to this match found, from all Chunks in this line
    							foreach (TextChunk chk in ThisLineChunks) {
    								sCurrentText = sCurrentText + chk.text;
    
    								//Check if we entered the part where we had found a matching String then get this Chunk (First Chunk)
    								if (!bStart && sCurrentText.Length - 1 >= iFromChar) {
    									FirstChunk = chk;
    									bStart = true;
    								}
    
    								//Keep getting Text from Chunks while we are in the part where the matching String had been found
    								if (bStart & !bEnd) {
    									sTextInUsedChunks = sTextInUsedChunks + chk.text;
    								}
    
    								//If we get out the matching String part then get this Chunk (last Chunk)
    								if (!bEnd && sCurrentText.Length - 1 >= iToChar) {
    									LastChunk = chk;
    									bEnd = true;
    								}
    
    								//If we already have first and last Chunks enclosing the Text where our String pSearchString has been found 
    								//then it's time to get the rectangle, GetRectangleFromText Function below this Function, there we extract the pSearchString locations
    								if (bStart & bEnd) {
    									FoundMatches.Add(GetRectangleFromText(FirstChunk, LastChunk, pSearchString, sTextInUsedChunks, iFromChar, iToChar, pStrComp));
    									curPos = curPos + pSearchString.Length;
    									bStart = false;
    									bEnd = false;
    									break; // TODO: might not be correct. Was : Exit For
    								}
    							}
    						}
    					}
    					sb.Clear();
    					ThisLineChunks.Clear();
    				}
    				ThisLineChunks.Add(chunk);
    				sb.Append(chunk.text);
    			}
    
    			return FoundMatches;
    		}
    
    		private iTextSharp.text.Rectangle GetRectangleFromText(TextChunk FirstChunk, TextChunk LastChunk, string pSearchString, string sTextinChunks, int iFromChar, int iToChar, System.StringComparison pStrComp)
    		{
    			//There are cases where Chunk contains extra text at begining and end, we don't want this text locations, we need to extract the pSearchString location inside
    			//for these cases we need to crop this String (left and Right), and measure this excedent at left and right, at this point we don't have any direct way to make a
    			//Transformation from text space points to User Space units, the matrix for making this transformation is not accesible from here, so for these special cases when
    			//the String needs to be cropped (Left/Right) We'll interpolate between the width from Text in Chunk (we have this value in User Space units), then i'll measure Text corresponding
    			//to the same String but in Text Space units, finally from the relation betweeenthese 2 values I get the TransformationValue I need to use for all cases
    
    			//Text Width in User Space Units
    			float LineRealWidth = LastChunk.PosRight - FirstChunk.PosLeft;
    
    			//Text Width in Text Units
    			float LineTextWidth = GetStringWidth(sTextinChunks, LastChunk.curFontSize, LastChunk.charSpaceWidth, ThisPdfDocFonts.Values[LastChunk.FontIndex]);
    			//TransformationValue value for Interpolation
    			float TransformationValue = LineRealWidth / LineTextWidth;
    
    			//In the worst case, we'll need to crop left and right:
    			int iStart = sTextinChunks.IndexOf(pSearchString, pStrComp);
    
    			int iEnd = iStart + pSearchString.Length - 1;
    
    			string sLeft = null;
    			if (iStart == 0)
    				sLeft = null;
    			else
    				sLeft = sTextinChunks.Substring(0, iStart);
    
    			string sRight = null;
    			if (iEnd == sTextinChunks.Length - 1)
    				sRight = null;
    			else
    				sRight = sTextinChunks.Substring(iEnd + 1, sTextinChunks.Length - iEnd - 1);
    
    			//Measure cropped Text at left:
    			float LeftWidth = 0;
    			if (iStart > 0) {
    				LeftWidth = GetStringWidth(sLeft, LastChunk.curFontSize, LastChunk.charSpaceWidth, ThisPdfDocFonts.Values[LastChunk.FontIndex]);
    				LeftWidth = LeftWidth * TransformationValue;
    			}
    
    			//Measure cropped Text at right:
    			float RightWidth = 0;
    			if (iEnd < sTextinChunks.Length - 1) {
    				RightWidth = GetStringWidth(sRight, LastChunk.curFontSize, LastChunk.charSpaceWidth, ThisPdfDocFonts.Values[LastChunk.FontIndex]);
    				RightWidth = RightWidth * TransformationValue;
    			}
    
    			//LeftWidth is the text width at left we need to exclude, FirstChunk.distParallelStart is the distance to left margin, both together will give us this LeftOffset
    			float LeftOffset = FirstChunk.distParallelStart + LeftWidth;
    			//RightWidth is the text width at right we need to exclude, FirstChunk.distParallelEnd is the distance to right margin, we substract RightWidth from distParallelEnd to get RightOffset
    			float RightOffset = LastChunk.distParallelEnd - RightWidth;
    			//Return this Rectangle
    			return new iTextSharp.text.Rectangle(LeftOffset, FirstChunk.PosBottom, RightOffset, FirstChunk.PosTop);
    		}
    
    		private float GetStringWidth(string str, float curFontSize, float pSingleSpaceWidth, DocumentFont pFont)
    		{
    			char[] chars = str.ToCharArray();
    			float totalWidth = 0;
    			float w = 0;
    
    			foreach (char c in chars) {
    				w = pFont.GetWidth(c) / 1000f;
    				totalWidth += (w * curFontSize + this.UndercontentCharacterSpacing) * this.UndercontentHorizontalScaling / 100;
    			}
    
    			return totalWidth;
    		}
    
    		private void DumpState()
    		{
    			foreach (TextChunk location in locationalResult) {
    				location.PrintDiagnostics();
    				Console.WriteLine();
    			}
    		}
    
    		public virtual void RenderText(TextRenderInfo renderInfo)
    		{
    			LineSegment segment = renderInfo.GetBaseline();
    			TextChunk location = new TextChunk(renderInfo.GetText(), segment.GetStartPoint(), segment.GetEndPoint(), renderInfo.GetSingleSpaceWidth());
    
    			var _with1 = location;
    
    			//Chunk Location:
    //			Debug.Print(renderInfo.GetText);
    			_with1.PosLeft = renderInfo.GetDescentLine().GetStartPoint()[Vector.I1];
    			_with1.PosRight = renderInfo.GetAscentLine().GetEndPoint()[Vector.I1];
    			_with1.PosBottom = renderInfo.GetDescentLine().GetStartPoint()[Vector.I2];
    			_with1.PosTop = renderInfo.GetAscentLine().GetEndPoint()[Vector.I2];
    			//Chunk Font Size: (Height)
    			_with1.curFontSize = _with1.PosTop - segment.GetStartPoint()[Vector.I2];
    			//Use Font name  and Size as Key in the SortedList
    			string StrKey = renderInfo.GetFont().PostscriptFontName + _with1.curFontSize.ToString();
    			//Add this font to ThisPdfDocFonts SortedList if it's not already present
    			if (!ThisPdfDocFonts.ContainsKey(StrKey))
    				ThisPdfDocFonts.Add(StrKey, renderInfo.GetFont());
    			//Store the SortedList index in this Chunk, so we can get it later
    			_with1.FontIndex = ThisPdfDocFonts.IndexOfKey(StrKey);
    			locationalResult.Add(location);
    		}
    
    		//*
    		//         * Represents a chunk of text, it's orientation, and location relative to the orientation vector
    		//         
    
    		public class TextChunk : IComparable<TextChunk>
    		{
    			//* the text of the chunk 
    
    			internal String text;
    			//* the starting location of the chunk 
    
    			internal Vector startLocation;
    			//* the ending location of the chunk 
    
    			internal Vector endLocation;
    			//* unit vector in the orientation of the chunk 
    
    			internal Vector orientationVector;
    			//* the orientation as a scalar for quick sorting 
    
    			internal int orientationMagnitude;
    			//* perpendicular distance to the orientation unit vector (i.e. the Y position in an unrotated coordinate system)
    			//             * we round to the nearest integer to handle the fuzziness of comparing floats 
    
    			internal int distPerpendicular;
    			//* distance of the start of the chunk parallel to the orientation unit vector (i.e. the X position in an unrotated coordinate system) 
    
    			internal float distParallelStart;
    			//* distance of the end of the chunk parallel to the orientation unit vector (i.e. the X position in an unrotated coordinate system) 
    
    			internal float distParallelEnd;
    			//* the width of a single space character in the font of the chunk 
    
    			internal float charSpaceWidth;
    
    			private float _PosLeft;
    
    			private float _PosRight;
    
    			private float _PosTop;
    
    			private float _PosBottom;
    
    			private float _curFontSize;
    
    			private int _FontIndex;
    			public int FontIndex {
    				get { return _FontIndex; }
    				set { _FontIndex = value; }
    			}
    
    			public float PosLeft {
    				get { return _PosLeft; }
    				set { _PosLeft = value; }
    			}
    
    			public float PosRight {
    				get { return _PosRight; }
    				set { _PosRight = value; }
    			}
    
    			public float PosTop {
    				get { return _PosTop; }
    				set { _PosTop = value; }
    			}
    
    			public float PosBottom {
    				get { return _PosBottom; }
    				set { _PosBottom = value; }
    			}
    
    			public float curFontSize {
    				get { return _curFontSize; }
    				set { _curFontSize = value; }
    			}
    
    			public TextChunk(String str, Vector startLocation, Vector endLocation, float charSpaceWidth)
    			{
    				this.text = str;
    				this.startLocation = startLocation;
    				this.endLocation = endLocation;
    				this.charSpaceWidth = charSpaceWidth;
    
    				Vector oVector = endLocation.Subtract(startLocation);
    				if (oVector.Length == 0) {
    					oVector = new Vector(1, 0, 0);
    				}
    				orientationVector = oVector.Normalize();
    				orientationMagnitude = Convert.ToInt32(Math.Truncate(Math.Atan2(orientationVector[Vector.I2], orientationVector[Vector.I1]) * 1000));
    
    				Vector origin = new Vector(0, 0, 1);
    				distPerpendicular = Convert.ToInt32((startLocation.Subtract(origin)).Cross(orientationVector)[Vector.I3]);
    
    				distParallelStart = orientationVector.Dot(startLocation);
    				distParallelEnd = orientationVector.Dot(endLocation);
    			}
    
    			public void PrintDiagnostics()
    			{
    				Console.WriteLine("Text (@" + Convert.ToString(startLocation) + " -> " + Convert.ToString(endLocation) + "): " + text);
    				Console.WriteLine("orientationMagnitude: " + orientationMagnitude);
    				Console.WriteLine("distPerpendicular: " + distPerpendicular);
    				Console.WriteLine("distParallel: " + distParallelStart);
    			}
    
    			//*
    			//             * @param as the location to compare to
    			//             * @return true is this location is on the the same line as the other
    			//             
    
    			public bool SameLine(TextChunk a)
    			{
    				if (orientationMagnitude != a.orientationMagnitude) {
    					return false;
    				}
    				if (distPerpendicular != a.distPerpendicular) {
    					return false;
    				}
    				return true;
    			}
    
    			//*
    			//             * Computes the distance between the end of 'other' and the beginning of this chunk
    			//             * in the direction of this chunk's orientation vector.  Note that it's a bad idea
    			//             * to call this for chunks that aren't on the same line and orientation, but we don't
    			//             * explicitly check for that condition for performance reasons.
    			//             * @param other
    			//             * @return the number of spaces between the end of 'other' and the beginning of this chunk
    			//             
    
    			public float DistanceFromEndOf(TextChunk other)
    			{
    				float distance = distParallelStart - other.distParallelEnd;
    				return distance;
    			}
    
    			//*
    			//             * Compares based on orientation, perpendicular distance, then parallel distance
    			//             * @see java.lang.Comparable#compareTo(java.lang.Object)
    			//             
    
    			public int CompareTo(TextChunk rhs)
    			{
    				if (object.ReferenceEquals(this, rhs)) {
    					return 0;
    				}
    				// not really needed, but just in case
    				int rslt = 0;
    				rslt = CompareInts(orientationMagnitude, rhs.orientationMagnitude);
    				if (rslt != 0) {
    					return rslt;
    				}
    
    				rslt = CompareInts(distPerpendicular, rhs.distPerpendicular);
    				if (rslt != 0) {
    					return rslt;
    				}
    
    				// note: it's never safe to check floating point numbers for equality, and if two chunks
    				// are truly right on top of each other, which one comes first or second just doesn't matter
    				// so we arbitrarily choose this way.
    				rslt = distParallelStart < rhs.distParallelStart ? -1 : 1;
    
    				return rslt;
    			}
    
    			//*
    			//             *
    			//             * @param int1
    			//             * @param int2
    			//             * @return comparison of the two integers
    			//             
    
    			private static int CompareInts(int int1, int int2)
    			{
    				return int1 == int2 ? 0 : int1 < int2 ? -1 : 1;
    			}
    		}
    
    		//*
    		//         * no-op method - this renderer isn't interested in image events
    		//         * @see com.itextpdf.text.pdf.parser.RenderListener#renderImage(com.itextpdf.text.pdf.parser.ImageRenderInfo)
    		//         * @since 5.0.1
    		//         
    
    		public void RenderImage(ImageRenderInfo renderInfo)
    		{
    			// do nothing
    		}
    	}
    }
    
    //=======================================================
    //Service provided by Telerik (www.telerik.com)
    //Conversion powered by NRefactory.
    //Twitter: @telerik
    //Facebook: facebook.com/telerik
    //=======================================================
