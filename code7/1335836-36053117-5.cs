    var result = new List<Tuple<string, string>>();
    foreach (var e in doc.Descendants().Where(o => o.Name == "old" || o.Name == "new"))
    {
    	XElement _old, _new;
    	//if current element is an <old> ...
    	if (e.Name == "old")
    	{
    		_old = e;
    		//if the next sibling is a <new>
    		if (e.NextNode != null && e.NextNode is XElement && ((XElement)e.NextNode).Name == "new")
    		{
    			_new = ((XElement)e.NextNode);
    		}
    		//else: <old> without matching <new>
    		else _new = null;
    		result.Add(Tuple.Create((string)_old, (string)_new));
    	}
    	//else: current element is a <new> ...
    	else
    	{
    		//make sure we add current <new> to the result only if it doesn't have matching <old>
    		//otherwise it would have been covered by the `if (e.Name == "old")` block
    		if (e.PreviousNode == null || !(e.PreviousNode is XElement) || ((XElement)e.PreviousNode).Name != "old")
    		{
    			_new = e;
    			_old = null;
    			result.Add(Tuple.Create((string)_old, (string)_new));
    		}
    	}
    }
