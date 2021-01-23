    public class RichTextBoxEx : RichTextBox
    {
        // combination of multiple events that may cause focus(caret) to change
        public event EventHandler FocusChanged;
    
        public RichTextBoxEx()
        {
            this.KeyPress += (s, e) => RaiseFocusChanged();
            this.KeyDown += (s, e) => RaiseFocusChanged();
            this.KeyUp += (s, e) => RaiseFocusChanged();
            this.MouseClick += (s, e) => RaiseFocusChanged();
        }
    
        private void RaiseFocusChanged()
        {
            var focusChanged = FocusChanged;
            if (focusChanged != null)
            {
                focusChanged(this, null);
            }
        }
    
        public int GetFirstSelectedLine()
        {
            var index = GetFirstCharIndexOfCurrentLine();
            return GetLineFromCharIndex(index);
        }
        public int GetFirstVisibleLine()
        {
            var index = GetCharIndexFromPosition(new Point(1, 1));
            return GetLineFromCharIndex(index);
        }
    
        public void ScrollToLine(int line)
        {
            if (line < 0)
                throw new ArgumentOutOfRangeException("line cannot be less than 0");
                
            // save the current selection to be restored later
            var selection = new { SelectionStart, SelectionLength };
    
            // select that line and scroll it to
            Select(GetFirstCharIndexFromLine(line) + 1, 0);
            ScrollToCaret();
    
            // restore selection
            Select(selection.SelectionStart, selection.SelectionLength);
        }
    }
