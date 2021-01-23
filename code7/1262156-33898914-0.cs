            //Writing bytes to a temporary file.
            string tempFontFileLoation = "testFont.ttf";
            File.WriteAllBytes(tempFontFileLoation, yourBytesHere);
            //Creating an instance of System.Windows.Media.GlyphTypeface.
            //From here we will read all the needed font details.
            var glyphTypeface = new GlyphTypeface(new Uri(tempFontFileLoation));
            //Reading font family name
            string fontFamilyName = String.Join(" ", glyphTypeface.FamilyNames.Values.ToArray<string>());
            //This is what we actually need... the right font family name, to be able to create a correct FontFamily Uri
            string fontUri = new Uri(tempFontFileLoation.Replace(Path.GetFileName(tempFontFileLoation), ""), UriKind.RelativeOrAbsolute).AbsoluteUri + "/#" + fontFamilyName;
            //And here is the instance of System.Windows.Media.FontFamily
            var fontFamily = new FontFamily(fontUri);
