    void DisableAllControls(Control ctrl) {
        foreach(Control c in ctrl.Controls) {
            if (c is TextBox) {
                ((TextBox)(c)).Enabled = false;
            }
            else if (c is DropDownList) {
                ((DropDownList)(c)).Enabled = false;
            }
            // and so on............
            DisableControls(c);
        }
    }
