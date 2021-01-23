    protected override void OnResize(EventArgs e)
	{
	    // supress flickering if dockstate is float
	    if (DockHandler.DockState == WeifenLuo.WinFormsUI.Docking.DockState.Float) {
			WpfInteropHelper.Suspend(this);
		}
		base.OnResize(e);
		if (DockHandler.DockState == WeifenLuo.WinFormsUI.Docking.DockState.Float) {
			WpfInteropHelper.Resume(this);
		}
	}
