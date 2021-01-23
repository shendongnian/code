    foreach (dynamic c in Controls) {
        ClearOut(c);
    }
    ...
    private static void ClearOut(ComboBox c) {
        c.SelectedIndex = -1;
    }
    private static void ClearOut(TextBox t) {
        t.Text = string.Empty;
    }
    private static void ClearOut(CheckBox c) {
        c.Checked = false;
    }
