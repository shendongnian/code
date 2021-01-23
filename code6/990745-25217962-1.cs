        private void RichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var caret = RichText.CaretPosition;
            Paragraph paragraph = RichText.Document.Blocks.FirstOrDefault(x => x.ContentStart.CompareTo(caret) == -1 && x.ContentEnd.CompareTo(caret) == 1) as Paragraph;
            if (paragraph != null)
            {
                Inline inline = paragraph.Inlines.FirstOrDefault(x => x.ContentStart.CompareTo(caret) == -1 && x.ContentEnd.CompareTo(caret) == 1) as Inline;
                if (inline != null)
                {
                    TextDecorationCollection decorations = inline.TextDecorations;
                    this.UnderlineButton.IsChecked = (decorations == DependencyProperty.UnsetValue) ? false : decorations != null && decorations.Contains(TextDecorations.Underline[0]);
                }
            }
        }
