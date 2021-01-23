        private void textBoxEnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;
            // ADDED THIS TO SIMULATE AcceptsReturn = True
            if (initialsCheckBox.IsChecked == false)
            {
                AppendText(mainTextBox, Environment.NewLine, "#000000");
                return;
            }
            Chumhandle active = getActiveHandleBox().SelectedItem as Chumhandle;
            // ADDED Environment.NewLine TO INSERT LINE BREAKS
            AppendText(mainTextBox, Environment.NewLine + initials + ": ", "#229922");
            // COMMENTED THIS BECAUSE IT WAS FORCING UNWANTED BEHAVIOR
            //TextPointer caretPos = mainTextBox.CaretPosition;
            //caretPos = caretPos.DocumentEnd;
            //mainTextBox.CaretPosition = caretPos;
        }
        public static void AppendText(RichTextBox box, string text, string color)
        {
            BrushConverter bc = new BrushConverter();
            // INSTEAD OF USING box.Document, I'VE USED box.Selection TO INSERT
            // THE TEXT WHEREVER THE CURSOR IS (OR IF YOU HAVE TEXT SELECTED)
            TextRange tr = new TextRange(box.Selection.Start, box.Selection.End);
            tr.Text = text;
            try
            {
                tr.ApplyPropertyValue(TextElement.ForegroundProperty, bc.ConvertFromString(color));
            }
            catch (FormatException) { }
            // I DON'T UNDERSTAND WHAT THIS IS DOING SO I KEPT IT -_^
            box.Selection.ApplyPropertyValue(RichTextBox.ForegroundProperty, bc.ConvertFromString(color));
            // FINALLY, I SET THE CARET TO THE END OF THE INSERTED TEXT
            box.CaretPosition = tr.End;
        }
