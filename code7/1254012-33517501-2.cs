	private void newPictureBox_Click(object sender, EventArgs e)
	{
		UserControl1 _UserControl = new UserControl1();
		PictureBox _PictureBox = (PictureBox)sender;
		string _NewControlClusterName = "_New" + _PictureBox.Name;
		_UserControl.Name = _NewControlClusterName;
		_UserControl.ThreadCount = 16;
		_UserControl.ImageBackground = _PictureBox.BackColor;
		_UserControl.Dock = DockStyle.Top;
		_UserControl.AllowDrop = true;
		_UserControl.Cursor = Cursors.SizeAll;
		_UserControl.MouseMove += _UserControl_MouseMove;
		_UserControl.DragDrop += _UserControl_DragDrop;
		_UserControl.DragEnter += _UserControl_DragEnter;
		string ColorName = toolTip1.GetToolTip(_PictureBox);
		string ColorCode = toolTip2.GetToolTip(_PictureBox);
		toolTip1.SetToolTip(_UserControl.pictureBox1, ColorName);
		toolTip2.SetToolTip(_UserControl.pictureBox1, ColorCode);
		toolTip2.Active = false;
		_UserControl.PictureClick += new EventHandler(ClusterControl_Click);
		_UserControl.TrackBarScroll += new EventHandler(GetTartanCode);
		foreach (Control subcontrol in _UserControl.Controls)
		{
			if (subcontrol.GetType() == typeof(GroupBox)){
				subcontrol.MouseMove += _UserControl_MouseMove;
				subcontrol.DragDrop += _UserControl_DragDrop;
				subcontrol.DragEnter += _UserControl_DragEnter;
			}
		}
			
		panel3.Controls.Add(_UserControl);
		panel3.Controls.SetChildIndex(_UserControl, 0);
	}
	private void _UserControl_DragEnter(object sender, DragEventArgs e)
	{
		e.Effect = DragDropEffects.All;
	}
	private void _UserControl_DragDrop(object sender, DragEventArgs e)
	{
		UserControl1 target = sender as UserControl1;
		if (target != null)
		{
			int targetIndex = FindUserControlIndex(target);
			if (targetIndex != -1)
			{
				string _UserControlFormat = typeof(UserControl1).FullName;
				if (e.Data.GetDataPresent(_UserControlFormat))
				{
					UserControl1 source = e.Data.GetData(_UserControlFormat) as UserControl1;
					int sourceIndex = this.FindUserControlIndex(source);
					if (targetIndex != -1)
						this.panel3.Controls.SetChildIndex(source, targetIndex);
				}
			}
		}
	}
	private int FindUserControlIndex(UserControl1 _UserControl)
	{
		for (int i = 0; i < this.panel3.Controls.Count; i++)
		{
			UserControl1 target = this.panel3.Controls[i] as UserControl1;
			if (_UserControl == target)
				return i;
		}
		return -1;
	}
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
