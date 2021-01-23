    //code
    protected override void OnMouseUp(MouseEventArgs e)
        {
            if(state != MouseState.Leave)
               state = MouseState.Over
            Invalidate();
            base.OnMouseUp(e);
        }
    //code
