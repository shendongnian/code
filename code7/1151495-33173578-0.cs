    public static class TextUtils
    {
    	public static IEnumerable<string> GetLines(this TextBlock source)
    	{
    		var text = source.Text;
    		int offset = 0;
    		var lineStart = source.ContentStart.GetPositionAtOffset(1, LogicalDirection.Forward);
    		do
    		{
    			var lineEnd = lineStart != null ? lineStart.GetLineStartPosition(1) : null;
    			int length = lineEnd != null ? lineStart.GetOffsetToPosition(lineEnd) : text.Length - offset;
    			yield return text.Substring(offset, length);
    			offset += length;
    			lineStart = lineEnd;
    		}
    		while (lineStart != null);
    	}
    }
