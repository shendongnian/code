      private static bool IsFontInstalled(string fontName)
        {
            try
            {
                using (var testFontFam = new FontFamily(fontName))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
