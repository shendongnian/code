	/// <summary>
    /// Extensions to SpriteFont.
    /// </summary>
    public static class SpriteFontExtensions
    {      
        /// <summary>
        /// Abstractly represents a substring by its start index and length.
        /// </summary>
        public struct SubString
        {
            public int StartIndex;
            public int Length;
        }
   
        private static List<SubString> _lines = new List<SubString>();
        
        /// <summary>
        /// Wraps a string into sub-string lines, each line no longer (in pixels) than the specified lineWidth.
        /// 
        /// JCF: This is a conversion of Torque3D's GFont::wrapString, available on GitHub. 
        /// </summary>
        public static void WrapString(this SpriteFont font, string inText, int lineWidth, int hangingIndentWidth, List<SubString> outLines)
        {
            // Early out, no text passed to us.
            if (string.IsNullOrEmpty(inText))
                return;
            var strb = new StringBuilder(inText);
            WrapString(font, strb, lineWidth, hangingIndentWidth, outLines);
        }
        /// <summary>
        /// Wraps a string into sub-string lines, each line no longer (in pixels) than the specified lineWidth.
        /// 
        /// JCF: This is a conversion of Torque3D's GFont::wrapString, available on GitHub
        /// </summary>
        public static void WrapString(this SpriteFont font, StringBuilder strb, int lineWidth, int hangingIndentWidth, List<SubString> outLines)
        {
            if (strb.Length == 0)
                return;
            var firstLetterWidth = font.MeasureString(strb[0].ToString()).X;
            // Early out, not even the first letter will fit within the lineWidth available.
            if (firstLetterWidth > lineWidth)
                return;
            var len = strb.Length;
            var startLine = 0;
            for (var i = 0; i < len;)
            {
                startLine = i;
                // loop until the string is too large
                var needsNewLine = false;
                var lineStrWidth = 0;
                for (; i < len; i++)
                {
                    if (strb[i] == '\n')
                    {
                        needsNewLine = true;
                        break;
                    }
                    var subStr = strb.Substring(startLine, (i - startLine) + 1);
                    lineStrWidth = (int) (font.MeasureString(subStr).X);
                    if (outLines.Count > 0)
                        lineStrWidth += hangingIndentWidth;
                    if (lineStrWidth > lineWidth)
                    {
                        needsNewLine = true;
                        break;
                    }
                }
                if (!needsNewLine)
                {
                    // we are done!
                    var line = new SubString()
                                   {
                                       StartIndex = startLine,
                                       Length = i - startLine,
                                   };
                    outLines.Add(line);
                    return;
                }
                var j = 0;
                // Did we hit a hardwrap (newline character) in the string.
                bool hardwrap = (strb[i] == '\n');
                if (hardwrap)
                {
                    j = i;
                }
                    // determine where to put the newline
                    // we need to backtrack until we find a space character 
                    // we don't do this for hardwrap(s)
                else
                {
                    for (j = i - 1; j >= startLine; j--)
                    {
                        if (char.IsSeparator(strb[j]))
                            break;
                    }
                    if (j < startLine)
                    {
                        // the line consists of a single word!              
                        // So, just break up the word
                        j = i - 1;
                    }
                }
                // 
                {
                    var line = new SubString()
                        {
                            StartIndex = startLine,
                            Length = j - startLine + 1,
                        };
                    outLines.Add(line);
                    i = line.StartIndex + line.Length;
                }
                // Now we need to increment through any space characters at the
                // beginning of the next line.
                // We don't skip spaces after a hardwrap because they were obviously intended.                
                for (; i < len; i++)
                {
                    if (strb[i] == '\n')
                        continue;
                    if (char.IsSeparator(strb[i]) && !hardwrap)
                        continue;
                    break;
                }
            }
        }
	}
}
