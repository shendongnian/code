	private void _UserControl_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			if (sender.GetType() == typeof(GroupBox))
			{
				GroupBox _GroupBox = sender as GroupBox;
				UserControl1 _UserControl1 = _GroupBox.Parent as UserControl1;
				_UserControl1.BorderStyle = BorderStyle.Fixed3D;
				_UserControl1.DoDragDrop(_UserControl1, DragDropEffects.All);
			}
			else
			{
				UserControl1 _UserControl1 = sender as UserControl1;
				_UserControl1.BorderStyle = BorderStyle.Fixed3D;
				_UserControl1.DoDragDrop(_UserControl1, DragDropEffects.All);
			}
		}
	}
