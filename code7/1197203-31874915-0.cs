            Paragraph paragraph232 = new Paragraph();
            ParagraphProperties paragraphProperties220 = new ParagraphProperties();
            SectionProperties sectionProperties1 = new SectionProperties();
            SectionType sectionType1 = new SectionType(){ Val = SectionMarkValues.NextPage };
            sectionProperties1.Append(sectionType1);
            paragraphProperties220.Append(sectionProperties1);
            paragraph232.Append(paragraphProperties220);
	//Replace your last but one line with this one.
	
	mainPart.Document
                    .Body
                    .Append(altChunk);
