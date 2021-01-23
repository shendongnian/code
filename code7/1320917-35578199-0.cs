    private void control_MouseDown(object sender, MouseEventArgs e)
    {
	  var control = sender as Control;
	  if (control == null)
		return;
	  var t = new System.Threading.Timer(s =>
	  {
	 	var callingControl = s as Control;
		if (callingControl == null)
	 	  return;
		Action x = () => DoDragDrop(callingControl.Name, DragDropEffects.Move);
		if (control.InvokeRequired)
		  control.Invoke(x);
		else
		  x();
	  }, control, SystemInformation.DoubleClickTime, Timeout.Infinite);
    }
