	[
	Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced),
	DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
	SRDescription(SR.ControlDisposedDescr)
	]
	public bool IsDisposed {
		get {
			return GetState(STATE_DISPOSED);
		}
	}
