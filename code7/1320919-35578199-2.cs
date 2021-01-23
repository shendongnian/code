    private bool _willDrag = false;
    private bool control_MouseUp(object sender, MouseEventArgs e)
    {
      // disable dragging if we release the mouse button
      _willDrag = false;
    }
    private bool control_DoubleClick(object sender, EventArgs e)
    {
      // disable dragging also if we double-click
      _willDrag = false;
      // .. the rest of your doubleclick event ...
    }
 
    private void control_MouseDown(object sender, MouseEventArgs e)
    {
	  var control = sender as Control;
	  if (control == null)
		return;
      _willDrag = true;
	  var t = new System.Threading.Timer(s =>
	  {
	 	var callingControl = s as Control;
		if (callingControl == null)
	 	  return;
        // if we released the mouse button or double-clicked, don't drag
        if(!_willDrag)
          return;
        _willDrag = false;
		Action x = () => DoDragDrop(callingControl.Name, DragDropEffects.Move);
		if (control.InvokeRequired)
		  control.Invoke(x);
		else
		  x();
	  }, control, SystemInformation.DoubleClickTime, Timeout.Infinite);
    }
