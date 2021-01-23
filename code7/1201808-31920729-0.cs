    void CheckChanges(Control.ControlCollection cc)
    {
        foreach (Control ctrl in cc)
        {
            MaskedTextBox mtxtBox = ctrl as MaskedTextBox;
            if (mtxtBox != null)
                mtxtBox.TextChanged += new EventHandler(this.TextWasChanged);
            TextBox txtBox = ctrl as TextBox;
            if (txtBox != null)
                txtBox.TextChanged += new EventHandler(this.TextWasChanged);
            ComboBox cmb = ctrl as ComboBox;
            if (cmb != null)
                cmb.SelectedIndexChanged += new EventHandler(this.TextWasChanged);
            //CheckChanges(ctrl.Controls);
        }
    }
