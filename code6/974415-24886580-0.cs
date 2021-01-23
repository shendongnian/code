    System.Windows.Forms.Integration.ElementHost elementHost1 = new System.Windows.Forms.Integration.ElementHost();
    System.Windows.Controls.TextBox textBox = new System.Windows.Controls.TextBox();
    textBox.Language = System.Windows.Markup.XmlLanguage.GetLanguage("en-GB");
    textBox.SpellCheck.IsEnabled = true;
    elementHost1.Child = textBox;
