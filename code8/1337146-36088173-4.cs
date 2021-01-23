     // Save the current position
     int caretIntPosition = GetIntPosition(Editor.CaretPosition, Editor);
     
     // Do your work ...
     
     // Restore the position
     SetIntPosition(caretIntPosition, Editor);
     
     /// <summary>
     /// Converts a TextPointer position into an int position.
     /// </summary>
     int GetIntPosition(TextPointer pointerPosition, RichTextBox rtb)
     {
         int intPosition = 0;
     
         TextPointer currentPosition = rtb.Document.ContentStart;
     
         while (currentPosition.CompareTo(pointerPosition) != 0)
         {
             intPosition++;
     
             currentPosition = currentPosition.GetNextInsertionPosition(LogicalDirection.Forward);
         }
     
         return intPosition;
     }
     
     /// <summary>
     /// Converts an int position back into a TextPointer position and places the caret there.
     /// </summary>
     void SetIntPosition(int intPosition, RichTextBox rtb)
     {
         TextPointer currentPosition = rtb.Document.ContentStart;
     
         for (int i = 1; i <= intPosition; i++)
         {
             currentPosition = currentPosition.GetNextInsertionPosition(LogicalDirection.Forward);
         }
     
         rtb.CaretPosition = currentPosition;
     }
