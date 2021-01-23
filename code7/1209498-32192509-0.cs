    void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
    	var c = e.Control;
    	var p = c.Parent;
    	SetStyles(p, ControlStyles.Opaque, true);
    }
    
    private static void SetStyles(Control c, ControlStyles styles, bool value) {
    	MethodInfo mi = typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);
    	mi.Invoke(c, new Object[] { styles, value });
    }
