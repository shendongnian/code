	/// <summary>
	/// Get the element at the viewport coordinates X, Y
	/// </summary>
	static public RemoteWebElement GetElementFromPoint(RemoteWebDriver i_Driver, int X, int Y)
	{
		while (true)
		{
			String s_Script = "return document.elementFromPoint(arguments[0], arguments[1]);";
			RemoteWebElement i_Elem = (RemoteWebElement)i_Driver.ExecuteScript(s_Script, X, Y);
			if (i_Elem == null)
				return null;
			if (i_Elem.TagName != "frame" && i_Elem.TagName != "iframe")
				return i_Elem;
			Point p_Pos = GetElementPosition(i_Elem);
			X -= p_Pos.X;
			Y -= p_Pos.Y;
			i_Driver.SwitchTo().Frame(i_Elem);
		}
	}
	/// <summary>
	/// Get the position of the top/left corner of the Element in the document.
	/// NOTE: RemoteWebElement.Location is always measured from the top of the document and ignores the scroll position.
	/// </summary>
	static public Point GetElementPosition(RemoteWebElement i_Elem)
	{
		String s_Script = "var X, Y; "
						+ "if (window.pageYOffset) " // supported by most browsers 
						+ "{ "
						+ "  X = window.pageXOffset; "
						+ "  Y = window.pageYOffset; "
						+ "} "
						+ "else " // Internet Explorer 6, 7, 8
						+ "{ "
						+ "  var  Elem = document.documentElement; "         // <html> node (IE with DOCTYPE)
						+ "  if (!Elem.clientHeight) Elem = document.body; " // <body> node (IE in quirks mode)
						+ "  X = Elem.scrollLeft; "
						+ "  Y = Elem.scrollTop; "
						+ "} "
						+ "return new Array(X, Y);";
		RemoteWebDriver i_Driver = (RemoteWebDriver)i_Elem.WrappedDriver;
		IList<Object>   i_Coord  = (IList<Object>)  i_Driver.ExecuteScript(s_Script);
		int s32_ScrollX = Convert.ToInt32(i_Coord[0]);
		int s32_ScrollY = Convert.ToInt32(i_Coord[1]);
		return new Point(i_Elem.Location.X - s32_ScrollX,
						 i_Elem.Location.Y - s32_ScrollY);
	}
