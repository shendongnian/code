        static IEnumerable<PdfFontInfo> ReadDocumentFonts(PdfReader reader)
        {
            if (reader.AcroForm == null)
                yield break;
            var dr = reader.AcroForm.GetAsDict(PdfName.DR);
            // Read font information from resources
            var fontDict = dr.GetAsDict(PdfName.FONT);
            foreach (var fontKey in fontDict.Keys)
            {
                var data = fontDict.GetAsDict(fontKey);
                // Read font descriptor if it possible
                var descriptor = data.GetAsDict(PdfName.FONTDESCRIPTOR);
                if (descriptor != null)
                {
                    // Read font name and family
                    var family = descriptor.GetAsString(PdfName.FONTFAMILY);
                    yield return new PdfFontInfo(fontKey, family.ToUnicodeString());
                }
            }
        }
        static IReadOnlyList<BaseFont> CreateSubstitutionFontsForFields(PdfReader reader)
        {
            if (reader.AcroForm.Fields == null)
                return new List<BaseFont>(0);
            var documentFontMap = ReadDocumentFonts(reader).ToDictionary(f => f.Name, StringComparer.InvariantCultureIgnoreCase);
            var substFonts = new Dictionary<string, BaseFont>();
            var fallbackRequired = false;
            // Read font information of each field
            foreach (var field in reader.AcroForm.Fields)
            {
                var fieldFontDa = field.Info.GetAsString(PdfName.DA);
                if (fieldFontDa == null)
                    continue;
                var parts = AcroFields.SplitDAelements(fieldFontDa.ToUnicodeString());
                if (parts.Length == 0)
                    continue;
                var fontName = (string) parts[0];
                PdfFontInfo inf;
                if (documentFontMap.TryGetValue(fontName, out inf))
                {
                    if (!substFonts.ContainsKey(fontName))
                    {
                        var font = FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, true).BaseFont;
                        substFonts.Add(fontName, font);
                    }
                }
                else
                    fallbackRequired = true;
            }
            var allFonts = new List<BaseFont>(substFonts.Values);
            if (fallbackRequired)
                allFonts.Add(FALLBACK_FONT);
            return allFonts;
        }
