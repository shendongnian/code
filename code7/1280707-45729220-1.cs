    public void SetAllControlsFont(ControlCollection ctrls) {
        foreach(Control c in ctrls) {
            if(c.Controls != null) {
                SetAllControlsFont(c.Controls);
            }
            c.Font = new Font("Tahoma", c.Font.Size);
        }
    }
