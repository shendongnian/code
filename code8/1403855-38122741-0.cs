        /// <devdoc>
        ///    <para>Raises the FormClosing event for this form when Application.Exit is called.
        ///          Returns e.Cancel returned by the event handler.</para>
        /// </devdoc>
        internal bool RaiseFormClosingOnAppExit() {
            FormClosingEventArgs e = new FormClosingEventArgs(CloseReason.ApplicationExitCall, false);
            OnFormClosing(e);
            return e.Cancel;
        }
