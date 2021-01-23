    private void ClearButtonClick (object sender, EventArgs e) {
        foreach (Control control in this.Controls) {
            if (control is CheckBox) {
                ((CheckBox)control).Checked = false;
            }
        }
    }
