    private IEnumerable<Control> GetAllControls(Control control)
    {
        var controls = control.Controls.Cast<Control>();
        return controls.SelectMany(ctrl => GetAllControls(ctrl)).Concat(controls);
    }
    private void ChangeTheme(string themeName)
    {
        GetAllControls(this).OfType<Button>().ToList()
            .ForEach(btn =>
            {
                btn.ImageList = this.components.Components
                                    .OfType<ImageList>()
                                    .Where(x => Convert.ToString(x.Tag).ToLower() == themeName.ToLower())
                                    .FirstOrDefault();
            });
    }
