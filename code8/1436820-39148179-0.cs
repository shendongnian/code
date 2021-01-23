    private void DoPerformCopy(object sender, EventArgs e)
    {
        RichTextBox rtb = new RichTextBox();
        foreach (TextMessage message in (listBox as ListBox)?.SelectedItems.Cast<TextMessage>().ToList())
        {
            ContentPresenter cp = new ContentPresenter();
            cp.Content = message;
            cp.ContentTemplate = listBox.ItemTemplate;
            cp.ApplyTemplate();
            var tb = VisualTreeHelper.GetChild(cp, 0) as TextBlock;
            var fg = tb.Foreground;
            var fw = tb.FontWeight;
    
            var tr = new TextRange(rtb.Document.ContentEnd, rtb.Document.ContentEnd);
            tr.Text = message.Content;
            tr.ApplyPropertyValue(RichTextBox.ForegroundProperty, fg);
            tr.ApplyPropertyValue(RichTextBox.FontWeightProperty, fw);
        }
        // Now copy the whole thing to the Clipboard
        rtb.Selection.Select(rtb.Document.ContentStart, rtb.Document.ContentEnd);
        rtb.Copy();
    }
