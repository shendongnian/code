    // parsing annotation in document
    	public static class Demo {
    
    		/* Parse PDf file annotations
    			*/
    		static void parseAnnotations( PdfReader reader, List<cMark> markers) {
    
    			markers.Clear();
    
    			// on each page
    			for(int pg = 1; pg < reader.NumberOfPages+1; pg++) {
    
    				PdfDictionary pagedic = reader.GetPageN( pg );
    				// get annotations array
    				PdfArray annotarray = (PdfArray)PdfReader.GetPdfObject( pagedic.Get( PdfName.ANNOTS ) );
    				// if no annotation ...
    				if (annotarray == null || annotarray.Size == 0) {
    					continue;
    					}
    
    				// on each annotation reference...
    				foreach(PdfIndirectReference annot in annotarray.ArrayList) {
    					
    					PdfDictionary annotationDic = (PdfDictionary)PdfReader.GetPdfObject( annot );
    					
    					PdfName subType = (PdfName)annotationDic.Get( PdfName.SUBTYPE );
    
    					PdfString contents = annotationDic.GetAsString( PdfName.CONTENTS );
    
    					// if simple text...
    					if (	(contents != null) &&
    							(	(subType.Equals( PdfName.TEXT )) || 
    								(subType.Equals( PdfName.FREETEXT ))
    							) 
    						) {
    						String value = contents.ToString();
    
    						// single marker element 
    						cMark mrk = new cMark(cMark.TypeMarker.TypeAnnotation, cMark.TypeAnnotationSubType.TypeAnnotation_NONE);
    						mrk.pageNum = pg;
    						mrk.title = value;
    
    						if (annotationDic.Get( PdfName.RECT ) != null) {
    							PdfArray coord = annotationDic.GetAsArray( PdfName.RECT );
    							PdfRectangle textRect = new PdfRectangle( 
    								((PdfNumber)coord[0]).FloatValue, 
    								((PdfNumber)coord[1]).FloatValue, 
    								((PdfNumber)coord[2]).FloatValue, 
    								((PdfNumber)coord[3]).FloatValue);
    
    							mrk.annotRect = textRect.Rectangle;
    							}
    
    						markers.Add( mrk);
    						}
    
    					// if decorated text...
    					if (	(subType.Equals( PdfName.UNDERLINE )) || 
    							(subType.Equals( PdfName.HIGHLIGHT )) || 
    							(subType.Equals( PdfName.STRIKEOUT )) || 
    							(subType.Equals( PdfName.SQUIGGLY )) ) {
    
    						cMark mrk = new cMark(cMark.TypeMarker.TypeAnnotation, cMark.TypeAnnotationSubType.TypeAnnotation_NONE);
    						mrk.pageNum = pg;
    
    						if (subType.Equals( PdfName.UNDERLINE )) {
    							mrk.eAnnotationSubType = cMark.TypeAnnotationSubType.TypeAnnotation_UNDERLINE;
    							}
    						else if (subType.Equals( PdfName.HIGHLIGHT )) {
    							mrk.eAnnotationSubType = cMark.TypeAnnotationSubType.TypeAnnotation_HIGHLIGHT;
    							}
    						else if (subType.Equals( PdfName.STRIKEOUT )) {
    							mrk.eAnnotationSubType = cMark.TypeAnnotationSubType.TypeAnnotation_STRIKEOUT;
    							}
    						else if (subType.Equals( PdfName.SQUIGGLY )) {
    							mrk.eAnnotationSubType = cMark.TypeAnnotationSubType.TypeAnnotation_SQUIGGLY;
    							}
    
    						PdfObject pdfObjectQuad = annotationDic.Get( PdfName.QUADPOINTS );
    						if (pdfObjectQuad != null) {
    							PdfArray rect = annotationDic.GetAsArray( PdfName.QUADPOINTS );
    							// float llx, float lly, float urx, float ury
    							float lowX = Math.Min( ((PdfNumber)rect[0]).FloatValue, ((PdfNumber)rect[2]).FloatValue);
    							lowX = Math.Min( lowX, ((PdfNumber)rect[4]).FloatValue);
    							lowX = Math.Min( lowX, ((PdfNumber)rect[6]).FloatValue);
    
    							float lowY = Math.Min( ((PdfNumber)rect[1]).FloatValue, ((PdfNumber)rect[3]).FloatValue);
    							lowY = Math.Min( lowY, ((PdfNumber)rect[5]).FloatValue);
    							lowY = Math.Min( lowY, ((PdfNumber)rect[7]).FloatValue);
    
    							float upX = Math.Max( ((PdfNumber)rect[0]).FloatValue, ((PdfNumber)rect[2]).FloatValue);
    							upX = Math.Max( upX, ((PdfNumber)rect[4]).FloatValue);
    							upX = Math.Max( upX, ((PdfNumber)rect[6]).FloatValue);
    
    							float upY = Math.Max( ((PdfNumber)rect[1]).FloatValue, ((PdfNumber)rect[3]).FloatValue);
    							upY = Math.Max( upY, ((PdfNumber)rect[5]).FloatValue);
    							upY = Math.Max( upY, ((PdfNumber)rect[7]).FloatValue);
    
    							PdfRectangle textRect = new PdfRectangle( lowX, lowY, upX, upY);
    							RenderFilter[] filter = { new RegionTextRenderFilter(textRect.Rectangle) };
    							ITextExtractionStrategy strategy;
    							StringBuilder sb = new StringBuilder();
    							for (int i = 1; i <= reader.NumberOfPages; i++) {
    								strategy = new FilteredTextRenderListener(new LocationTextExtractionStrategy(), filter);
    								sb.AppendLine(PdfTextExtractor.GetTextFromPage(reader, i, strategy));
    								}
    							String result = sb.ToString();
    							mrk.title = result;
    							mrk.annotRect = textRect.Rectangle;
    							markers.Add( mrk);
    							}
    						}
    					}
    				}
    			}
    		}
