        public static void Initialize(Control control, ControlVisitor visitor)
        {
            if (control == null) //can this ever be null?
            {
                return;
            }
            var customControl = control as ICustomControl;
            if (customControl != null)
            {
               customControl.Accept(visitor);
            }
    
            foreach (Control subControl in control.Controls)
            {
                Initialize(subControl, visitor);
            }
        }
