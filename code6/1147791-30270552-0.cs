    var controls = GetControls(parent);
    
    public IEnumerable<Control> GetControls(Control parent)
    {
        foreach(var control in parent.Controls)
        {
            yield return control;
            var childControls = GetControls(control);
            foreach(var child in childControls)
            {
                yield return child;
            }
        }
    }
