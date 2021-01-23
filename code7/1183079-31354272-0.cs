    private double _mX; // holds current eventData.position.x
    private double _mY; // holds current eventData.position.y
    private double _pmX;// holds previous eventData.position.x
    private double _pmY;// holds previous eventData.position.y
    
    // Updates the current position of the mouse.
    private void MouseOver(PointerEventData eventData)
    {
        _mX = eventData.position.x;
        _mY = eventData.position.y;
    }
    public void OnDrag (PointerEventData eventData)
    {
        transform.position = new Vector3D((_pmX - _mX)/6 + transform.position.x,
                                          (_mY - _pmY)/6 + transform.position.y, distance);
        // Divided the difference by 6 to reduce the speed of dragging.
        //...
        // end of the drag. set the previous position.
        _pmX = _mX;
        _pmY = _mY;
    }
