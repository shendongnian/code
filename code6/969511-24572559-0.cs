    private void Form1_Load(System.Object sender, System.EventArgs e)
    {
	UpdateLabelFG(this.Controls, Color.Red);
    }
   
    private void UpdateLabelFG(ControlCollection controls, Color fgColor)
    {
	if (controls == null)
		return;
	foreach (Control C in controls) {
		if (C is Label)
			((Label)C).ForeColor = fgColor;
		if (C.HasChildren)
			UpdateLabelFG(C.Controls, fgColor);
	}
    }
