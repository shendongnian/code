    /// <summary>
	/// Clicks any control on a page for the given area.
	/// </summary>
	/// <param name="controlObject">Control Object to Click</param>
	public static void ClickControl(UITestControl controlObject, int offset = 5)
	{
		Rectangle clickArea = controlObject.BoundingRectangle;
		Point clickPoint = new Point(clickArea.X + offset, clickArea.Y + offset);
		Mouse.Click(clickPoint);
	}
