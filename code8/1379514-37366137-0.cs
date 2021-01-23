    public static class RichTextExtensions
    {
        /// <summary>
        /// Searches for text in a RichTextBox control by color and selects it if found.
        /// </summary>
        /// <param name="rtb">The target RichTextBox.</param>
        /// <param name="color">The color of text to search for.</param>
        /// <param name="startIndex">The starting index to begin searching from (optional).  
        /// If this parameter is null, the search will begin at the point immediately
        /// following the current selection or cursor position.</param>
        /// <returns>If text of the specified color was found, the method returns the index 
        /// of the character following the selection; otherwise, -1 is returned.</returns>
        public static int SelectTextByColor(this RichTextBox rtb, Color color, int? startIndex = null)
        {
            if (rtb == null || rtb.Text.Length == 0) return -1;
            if (startIndex == null)
            {
                if (rtb.SelectionLength > 0) 
                    startIndex = rtb.SelectionStart + rtb.SelectionLength;
                else if (rtb.SelectionStart == rtb.Text.Length) 
                    startIndex = 0;
                else 
                    startIndex = rtb.SelectionStart;
            }
            int matchStartIndex = rtb.FindTextByColor(color, startIndex.Value, true);
            if (matchStartIndex == rtb.Text.Length)
            {
                rtb.Select(matchStartIndex, 0);
                return -1;
            }
            int matchEndIndex = rtb.FindTextByColor(color, matchStartIndex, false);
            rtb.Select(matchStartIndex, matchEndIndex - matchStartIndex);
            return matchEndIndex;
        }
        private static int FindTextByColor(this RichTextBox rtb, Color color, int startIndex, bool match)
        {
            if (startIndex < 0) startIndex = 0;
            for (int i = startIndex; i < rtb.Text.Length; i++)
            {
                rtb.Select(i, 1);
                if ((match && rtb.SelectionColor == color) || 
                    (!match && rtb.SelectionColor != color))
                    return i;
            }
            return rtb.Text.Length;
        }
    }
