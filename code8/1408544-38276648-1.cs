    public static class RichTextBoxExtensions
    {
        public static void MyCustomMethod(this RichTextBox self)
        {
            MessageBox.Show("It works, this textbox has " + self.Text + " as the text!");
        }
    }
