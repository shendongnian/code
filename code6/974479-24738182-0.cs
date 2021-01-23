    XElement xmlTree = XElement.Parse("<root><b>Should be bold</b>Shouldn't be bold</root>");
    AddRuns(BlockInstructions.Inlines, xmlTree);
	void AddRuns(InlineCollection inlines, XNode node, bool isBold = false, bool  isItalic = false)
	{	
		var inline = new Run {
			FontWeight = isBold ? FontWeights.Bold : FontWeights.Normal,
			FontStyle = isItalic ? FontStyles.Italic : FontStyles.Normal
		};
		inlines.Add(inline);
		var element = node as XElement;
		if (null != element)
		{
			foreach (var item in element.Nodes())
			{
				AddRuns(
                    inline.SiblingInlines,
                    item,
                    element.Name.LocalName == "b" || isBold,
                    element.Name.LocalName == "i" || isItalic
                );
			}
		}
		else
		{
			inline.Text = Convert.ToString(node);
		}
	}
