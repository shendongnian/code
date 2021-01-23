    /// <summary>
    /// This will get the text of the ITextView line as it appears in the actual user editable 
    /// document. 
    /// jared parson: https://gist.github.com/4320643
    /// </summary>
    public static bool TryGetText(IWpfTextView textView, ITextViewLine textViewLine, out string text)
    {
        var extent = textViewLine.Extent;
        var bufferGraph = textView.BufferGraph;
        try
        {
            var collection = bufferGraph.MapDownToSnapshot(extent, SpanTrackingMode.EdgeInclusive, textView.TextSnapshot);
            var span = new SnapshotSpan(collection[0].Start, collection[collection.Count - 1].End);
            //text = span.ToString();
            text = span.GetText();
            return true;
        }
        catch
        {
            text = null;
            return false;
        }
    }
    Regex todoLineRegex = new Regex(@"\/\/\s*TODO\b");
    private void CreateVisuals(ITextViewLine line)
    {
        IWpfTextViewLineCollection textViewLines = _view.TextViewLines;
        string text = null;
        if (TryGetText(_view, line, out text))
        {
            var match = todoLineRegex.Match(text);
            if (match.Success)
            {
                int matchStart = line.Start.Position + span.Index;
                var span = new SnapshotSpan(_view.TextSnapshot, Span.FromBounds(matchStart, matchStart + match.Length));
                DrawAdornment(textViewLines, span);
            }
        }
    }
