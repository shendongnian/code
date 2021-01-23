    // Get the selection object.
    var viewHost = GetCurrentViewHost();
    ITextSelection selection = viewHost.TextView.Selection;
    
    // Get the start and end points of the selection.
    VirtualSnapshotPoint start = selection.Start;
    VirtualSnapshotPoint end = selection.End;
    
    // Get the lines that contain the start and end points.
    IWpfTextViewLine startLine =
        viewHost.TextView.GetTextViewLineContainingBufferPosition(start.Position);
    IWpfTextViewLine endLine =
        viewHost.TextView.GetTextViewLineContainingBufferPosition(end.Position);
    
    // Get the start and end points of the lines.
    SnapshotPoint startLinePoint = startLine.Start;
    SnapshotPoint endLinePoint = endLine.End;
    
    // Create a SnapshotSpan for all text to be replaced.
    SnapshotSpan span = new SnapshotSpan(startLinePoint, endLinePoint);
    
    // Compute margin.
    string[] lines = span.GetText().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    int margin = lines.Select(line =>
    {
        int count = 0;
        while (char.IsWhiteSpace(line[count++])) ;
        return --count;
    }).Min();
    
    // Construct the replacement string.
    StringBuilder sb = new StringBuilder();
    foreach (string line in lines)
    {
        sb.AppendLine(String.Format("{0}{1} {2}", new string(' ', margin), "///", line.Remove(0, margin)));
    }
    
    // Perform the replacement.
    span.Snapshot.TextBuffer.Replace(span, sb.ToString());
