        public static void Initialize(IEnumerable<IInitializer> initializers, Control control, DocumentContainer container, ErrorProvider provider)
        {
            if (control == null) return;
            var inSituInitializer = control as IInitializer;
            if (inSituInitializer != null)
            {
                inSituInitializer.Intialize(control, container, provider);
            }
            else
            {
                foreach (var initializer in initializers)
                {
                    if (initializer.Accept(control))
                    {
                        initializer.Intialize(control, container, provider);
                        break;
                    }
                }
            }
            foreach (Control subControl in control.Controls)
            {
                Initialize(initializers, subControl, container, provider);
            }
        }
