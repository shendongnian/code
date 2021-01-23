    public static class Utility{
        ///for System.Windows.Forms.TextBox
        public static System.Drawing.Point GetCaretPont(System.Windows.Forms.TextBox textBox)
        {
        return textBox.GetPositionFromCharIndex(textBox.SelectionStart);
        }
        ///for System.Windows.Controls.TextBox
        public static System.Windows.Point GetCaretPont(System.Windows.Controls.TextBox textBox)
        {
          return textBox.GetRectFromCharacterIndex(textBox.SelectionStart).Location;
        }
    }
