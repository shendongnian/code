    public IEnumerable<Control> GetAll(Control control)
    {
        var controls = control.Controls.Cast<Control>();
        return controls.SelectMany(x => GetAll(x)).Concat(controls);
    }
    protected override bool ProcessMnemonic(char charCode)
    {
        var controls = GetAll(this).Where(x => x.Visible && x.Enabled &&
            Control.IsMnemonic(charCode, x.Text)).ToList();
        var index = controls.IndexOf(controls.Where(x => x.Focused).FirstOrDefault());
        List<Control> list = new List<Control>();
        list.AddRange(controls.Skip(index + 1).Take(controls.Count - index + 1));
        list.AddRange(controls.Take(index + 1));
        var c= list.Where(x => !x.Focused).FirstOrDefault();
        if (c != null) { c.Focus(); return true; }
        return false;
    }
