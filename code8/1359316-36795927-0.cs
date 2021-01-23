	private void UpdateFormattedText()
	{
		if (Element?.FormattedText == null)
			return;
		var extensionType = typeof(FormattedStringExtensions);
		var type = extensionType.GetNestedType("FontSpan", BindingFlags.NonPublic);
		var ss = new SpannableString(Control.TextFormatted);
		var spans = ss.GetSpans(0, ss.ToString().Length, Class.FromType(type));
		foreach (var span in spans)
		{
			var font = (Font)type.GetProperty("Font").GetValue(span, null);
			if ((font.FontFamily ?? Element.FontFamily) != null)
			{
				var start = ss.GetSpanStart(span);
				var end = ss.GetSpanEnd(span);
				var flags = ss.GetSpanFlags(span);
				ss.RemoveSpan(span);
				var newSpan = new CustomTypefaceSpan(Control, Element, font);
				ss.SetSpan(newSpan, start, end, flags);
			}
		}
		Control.TextFormatted = ss;
	}
