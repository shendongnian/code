    var formattedTextToDraw = new List<FormattedText>();
    foreach (var paragraph in RichTextBox.Document.OfType<Paragraph>())
    {
        foreach(var inline in paragraph)
        {
            formattedTextToDraw.Add(new FormattedText(
                inline.Text, //Text
                inline.FontSize, //Fontsize
                inline.Foreground, //Color
                etc....) //Other properties for FormattedText constructor
        }
    }
