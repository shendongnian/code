    foreach (Control ctrl in this.Controls.OfType<Control>().ToList())
    {
        if ((ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(ComboBox))
            && ctrl.Tag.ToString() == btn.Tag.ToString())
        {
            ctrl.Dispose();
        }
    }
