    private void activeMdiChild _KeyDown(object sender, KeyEventArgs e) {
       if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
			{
              dynamic parent = this.Parent;
              parent.Save();
			} 
    }
