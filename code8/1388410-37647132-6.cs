    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (_bZoomWindowing)
            UpdateRubberBandRectangle(e.Location);
    
        if (_bPanWindowMode)
            UpdateRubberBandLine(e.Location);
    
        base.OnMouseMove(e);
    }
    
    private void UpdateRubberBandRectangle(Point Location)
    {
        // Do we need to erase the old one?
        if (!_rcLastRubberBand.IsEmpty)
        {
            using (Region r = new Region(Rectangle.Inflate(_rcLastRubberBand, 2, 2)))
            {
                r.Exclude(Rectangle.Inflate(_rcLastRubberBand, -2, -2));
    
                _pDevice.invalidate(new OdGsDCRect(_rcLastRubberBand.Left - 2, _rcLastRubberBand.Right + 2,
                                               _rcLastRubberBand.Top - 2, _rcLastRubberBand.Bottom + 2));
                Invalidate(r);
            }
        }
    
        // Draw the new one
        if (!_selectionStart.IsEmpty && !_selectionEnd.IsEmpty && _selectionEnd != Location)
        {
            _rcLastRubberBand = _rcRubberBand;
    
            _selectionEnd = Location;
            _rcRubberBand = GetSelectionRectangle(_selectionStart, _selectionEnd);
    
            using (Region r = new Region(Rectangle.Inflate(_rcRubberBand, 2, 2)))
            {
                r.Exclude(Rectangle.Inflate(_rcRubberBand, -2, -2));
    
                _pDevice.invalidate(new OdGsDCRect(_rcRubberBand.Left - 2, _rcRubberBand.Right + 2,
                                               _rcRubberBand.Top - 2, _rcRubberBand.Bottom + 2));
                Invalidate(r);
            }
        }
    }
    
    private void UpdateRubberBandLine(Point Location)
    {
        // Do we need to erase the last rubber band line? (Rectangle already expanded by 2 pixels)
        if (!_rcLastRubberBandLine.IsEmpty)
        {
            using (Region r = new Region(_rcLastRubberBandLine))
            {
                _pDevice.invalidate(new OdGsDCRect(_rcLastRubberBandLine.Left, _rcLastRubberBandLine.Right,
                                                   _rcLastRubberBandLine.Top, _rcLastRubberBandLine.Bottom));
                Invalidate(r);
            }
    
        }
    
        // Draw the new one now
        _RubberLineEnd = Location;
        _rcLastRubberBandLine = GetSelectionRectangle(_RubberLineStart, _RubberLineEnd);
        _rcLastRubberBandLine.Inflate(2, 2);
        using (Region r = new Region(_rcLastRubberBandLine))
        {
            _pDevice.invalidate(new OdGsDCRect(_rcLastRubberBandLine.Left, _rcLastRubberBandLine.Right,
                                               _rcLastRubberBandLine.Top, _rcLastRubberBandLine.Bottom));
            Invalidate(r);
        }
    }
