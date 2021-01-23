        private int privLineID = 1; 
        public int LineID
        {
            get { return privLineID; }
            set 
            { 
                privLineID = value;
                LabellineNr.Content = "Line: " + value;
            }
        }
        private int privColumnID = 1; 
        public int ColumnID
        {
            get { return privColumnID; }
            set 
            { 
                privColumnID = value;
                LabelColumnNr.Content = "Column: " + value;
            }
        }
        private int LineNumber()
        {
            TextPointer caretLineStart = RichTextControl.CaretPosition.GetLineStartPosition(0);
            TextPointer p = RichTextControl.Document.ContentStart.GetLineStartPosition(0);
            int currentLineNumber = 1;
            
            while (true)
            {
                if (caretLineStart.CompareTo(p) < 0)
                {
                    break;
                }
                int result;
                p = p.GetLineStartPosition(1, out result);
                if (result == 0)
                {
                    break;
                }
                currentLineNumber++;
            }
            return currentLineNumber;
        }
        private int ColumnNumber()
        {
            TextPointer caretPos = RichTextControl.CaretPosition;
            TextPointer p = RichTextControl.CaretPosition.GetLineStartPosition(0);
            int currentColumnNumber = Math.Max(p.GetOffsetToPosition(caretPos) - 1, 0);
            return currentColumnNumber;
        } 
