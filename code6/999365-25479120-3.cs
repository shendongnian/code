        /// <summary>
        /// Override CreateParams property so we can add "WS_CHILD" to
        /// the Style each time it is queried during window creation.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                // get the base params and modify them
                CreateParams cp = base.CreateParams;
                cp.Style |= NativeMethods.WindowStyles.WS_CHILD;
                return cp;
            }
        }
