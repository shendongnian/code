    public class MyFontResolver : IFontResolver
    {
        public FontResolverInfo ResolveTypeface(string familyName, 
                                                bool isBold, 
                                                bool isItalic)
        {
            // Ignore case of font names.
            var name = familyName.ToLower();
            // Add fonts here
            switch (name)
            {
                case "arial unicode ms":
                    return new FontResolverInfo("ArialUnicodeMS#");
            }
            //Return a default font if the font couldn't be found
            //this is not a unicode font 
            return PlatformFontResolver.ResolveTypeface("Arial", isBold, isItalic);
        }
        // Return the font data for the fonts.
        public byte[] GetFont(string faceName)
        {
            switch (faceName)
            {
                case "ArialUnicodeMS#": return FontHelper.ArialUnicodeMS; break;
            }
            return null;
        }
    }
