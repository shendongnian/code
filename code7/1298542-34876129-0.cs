	private void getSelectedXPathToolStripMenuItem_Click(object sender, EventArgs e)
	{
		var doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
		IHTMLElement selectedElement = null;
		var sel = doc.selection;
		if (sel.type == "Text")
			selectedElement = ((IHTMLTxtRange)sel.createRange()).parentElement();
		else if (sel.type == "Control")
			selectedElement = ((IHTMLControlRange)sel.createRange()).commonParentElement();
		
		var node = (IHTMLDOMNode)selectedElement;
		MessageBox.Show(GetXPath(node, true));
	}
	
	string GetXPath(IHTMLDOMNode node, bool stopAtId)
	{
		var path = new Stack<string>();
		while (node != null && node as IHTMLDocument2 == null)
		{
			var index = 0;
			// find previous siblings with the same tag name
			var prev = node.previousSibling;
			while (prev != null)
			{
				if (prev.nodeType == 1 && prev.nodeName == node.nodeName)
					index++;
				prev = prev.previousSibling;
			}
			var showIndex = index > 0;
			// if there were none, find if there are any next siblings with the same tag name
			var next = node.nextSibling;
			while (next != null)
			{
				if (next.nodeType == 1 && next.nodeName == node.nodeName)
				{
					showIndex = true;
					break;
				}
				next = next.nextSibling;
			}
			var id = ((IHTMLDOMAttribute2)((IHTMLAttributeCollection2)node.attributes).getNamedItem("id")).value;
			if (id != string.Empty)
			{
				showIndex = false;
			}
			var part = node.nodeName + (showIndex ? string.Format("[{0}]", index + 1) : string.Empty) + (id != string.Empty ? string.Format("[@id = '{0}']", id) : string.Empty);
			path.Push(part);
			node = node.parentNode;
			if (id != string.Empty && stopAtId)
				break;
		}
	
		return string.Join("/", path);
	}
