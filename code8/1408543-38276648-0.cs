    public static class RichTextBoxExtensions
    {
        public void MyCustomMethod(this RichTextBox self)
        {
            MessageBox.Show("It works, this textbox has " + self.Text + " as the text!");
        }
    }
