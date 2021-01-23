    public override void Write(string value)
    {
        this.console.Invoke(
            (Action<RichTextBox, string, Color>)RichTextBoxExtensions.AppendText,
            new object[] { this.console, value, Color.White });
    }
