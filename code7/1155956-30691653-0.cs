        public static void Initialize(Control control, DocumentContainer container, ErrorProvider provider)
        {
            if (control == null)
            {
                return;
            }
            var custom = control as ICustomControl;
            if (custom != null)
            {
                custom.DocumentLoaded = true;
                custom.Initialize(container, provider);
            }
            foreach (Control subControl in control.Controls)
            {
                Initialize(subControl, container, provider);
            }
        }
