    private Point _lastMove;
    private void OnMouseMove(object sender, MouseEventArgs e)
    {                        
        var p = e.GetPosition((IInputElement)sender);
        if (_lastMove != p) {
            // really moved
            _lastMove = p;
        }
    }
