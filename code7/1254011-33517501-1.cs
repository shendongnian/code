	foreach (Control subcontrol in _UserControl.Controls)
	{
		if (subcontrol.GetType() == typeof(GroupBox)){
			subcontrol.MouseMove += _UserControl_MouseMove;
			subcontrol.DragDrop += _UserControl_DragDrop;
			subcontrol.DragEnter += _UserControl_DragEnter;
		}
	}
