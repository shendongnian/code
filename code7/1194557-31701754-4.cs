    TextPointer text = richTextBox.Document.ContentStart;
    while (text.GetPointerContext(LogicalDirection.Forward) != TextPointerContext.Text)
    {
        text = text.GetNextContextPosition(LogicalDirection.Forward);
    }
    TextPointer startPos = text.GetPositionAtOffset(0);
    TextPointer endPos = text.GetPositionAtOffset(endmarker);
    var textRange = new TextRange(startPos, endPos);
    textRange.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Blue));
