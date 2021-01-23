        private static bool IsBOMWhitespace(char c)
        {
    #if FEATURE_LEGACYNETCF
            if (CompatibilitySwitches.IsAppEarlierThanWindowsPhone8 && c == '\xFEFF')
            {
                // Dev11 450846 quirk:
                // NetCF treats the BOM as a whitespace character when performing trim operations.
                return true;
            }
            else
    #endif
            {
                return false;
            }
        }
