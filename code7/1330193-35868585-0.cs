    [STAThread]
    static void Main(string[] args)
    {
        if (Clipboard.ContainsText(TextDataFormat.Text))
        {
            string clipboardText = Clipboard.GetText(TextDataFormat.Text);
            // Do whatever you need to do with clipboardText
        }
    }
