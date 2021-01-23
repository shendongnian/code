        public IEnumerable<Control> GetChildControls(Control parentControl)
        {
            List<Control> controls = new List<Control>();
            foreach (Control child in parentControl.Controls)
            {
                controls.AddRange(GetChildControls(child));
            }
            controls.Add(parentControl);
            return controls;
        }
