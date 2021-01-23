    private readonly ISet<char> keysCurrentlyDown = new HashSet<char>();
    private void FrmGM_KeyDown(object sender, KeyEventArgs e) {            
        if (e.KeyCode == Keys.W)
        {
            if (keysCurrentlyDown.Contains('D')) {
                // Call some method to handle W+D
            } else {
                ...
            }
            keysCurrentlyDown.Add('W');
        } else if (e.KeyCode == Keys.D)
        {
            if (keysCurrentlyDown.Contains('W')) {
                // Call some method to handle W+D
            } else {
                ...
            }
            keysCurrentlyDown.Add('D');
        }
        ...
    }
    private void FrmGM_KeyUp(object sender, KeyEventArgs e) {            
        if (e.KeyCode == Keys.W) {
            keysCurrentlyDown.Remove('W');
        } else if (e.KeyCode == Keys.D) {
            keysCurrentlyDown.Remove('D');
        } ...
    }
    }
