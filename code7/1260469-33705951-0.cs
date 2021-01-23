    public static class ControlExtensions
    {
        public static IEnumerable<Control> GetAllControls(this Control containerControl)
        {
            var controls = Enumerable.Empty<Control>();
            controls = controls.Concat(containerControl.Controls.Cast<Control>());
            foreach (Control control in containerControl.Controls)
            {
                controls = controls.Concat(control.GetAllControls());
            }
            return controls;
        }
    }
