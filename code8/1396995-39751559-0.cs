    IEnumerable<SelectionSegment> selectionSegments = Editor.TextArea.Selection.Segments;
    TextDocument document = Editor.TextArea.Document;
    foreach (SelectionSegment segment in selectionSegments)
    {
        //DO WHAT YOU WANT WITH THE SELECTIONS
		int lineStart = document.GetLineByOffset(segment.StartOffset).LineNumber;
		int lineEnd = document.GetLineByOffset(segment.EndOffset).LineNumber;
		for (int i = lineStart; i <= lineEnd; i++)
		{
			//Do something with each line in the selection segment
		}
    }
