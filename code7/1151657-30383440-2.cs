    // Scan every character in format and match the pattern in str.
    while (format.GetNext()) {
        // We trim inner spaces here, so that we will not eat trailing spaces when
        // AllowTrailingWhite is not used.
        if (parseInfo.fAllowInnerWhite) {
            str.SkipWhiteSpaces();
        }
        if (!ParseByFormat(ref str, ref format, ref parseInfo, dtfi, ref result)) {
           return (false);
        }
    }
