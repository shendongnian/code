    var txtToHighlight = (sender as TextBox)?.Text;
    if (!string.IsNullOrWhiteSpace(txtToHighlight))
    {
        var tb = MyTb;
        var currentTxt = tb.Text;
        tb.Inlines.Clear();
        var ix = currentTxt.IndexOf(txtToHighlight);
        if (ix >= 0)
        {
            var highlightContent = new Span { Foreground = new SolidColorBrush(Colors.Red) };
            highlightContent.Inlines.Add(new Run { Text = currentTxt.Substring(ix, txtToHighlight.Length) });
            tb.Inlines.Add(new Run { Text = currentTxt.Substring(0, ix) });
            tb.Inlines.Add(highlightContent);
            tb.Inlines.Add(new Run { Text = currentTxt.Substring(ix + txtToHighlight.Length) });
        }
        else
        {
            tb.Text = currentTxt;
        }
    }
