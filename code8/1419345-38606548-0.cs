    private void activeMdiChild _KeyPress(object sender, KeyPressEventArgs e) {
       if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
			{
              dynamic parent = this.Parent;
              parent.Save();
			} 
    }
