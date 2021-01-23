    protected override void OnMouseDown(MouseEventArgs e)
    {
        // when button is pressed, create a new _currentLine instance
        _currentLine = new Line() { Start = e.Location, End = e.Location };
        Invalidate();
        base.OnMouseDown(e);
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        // when mouse is moved, update the End position
        if (_currentLine != null)
        {
            _currentLine.End = e.Location;
            Invalidate();
        }
        base.OnMouseMove(e);
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        // when button is released, add the line to the list
        if (_currentLine != null)
        {
            _lines.Add(_currentLine);
            _currentLine = null;
            Invalidate();
        }
        base.OnMouseUp(e);
    }
