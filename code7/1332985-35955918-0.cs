        /// <summary>
        /// Looks for the last Modal Form in OpenForms that is AFTER justActivatedForm;
        /// if it finds it, then it Activates it and returns it. Otherwise, it returns null.
        /// </summary>
        /// <param name="justActivatedForm">The Form that was just Activated, prompting this check for Modal.</param>
        /// <returns>Returns the last Modal Form AFTER justActivatedForm; or null if no such exists.</returns>
        public static Form ActivateLastModalForm(Form justActivatedForm)
        {
            // Is there a Modal Form after justActivatedForm?  If so, get the last Modal Form.
            Form lastModal = null;
            bool foundJustActivatedForm = false;
            foreach (Form form in Application.OpenForms)
            {
                if (foundJustActivatedForm)
                {
                    if (form.Modal)
                        lastModal = form;
                }
                else if (form == justActivatedForm)
                {
                    foundJustActivatedForm = true;
                }
            }
            // If last Modal Form is found after justActivatedForm, Activate it
            if (lastModal != null)
            {
                LOG.Focus("Found Modal Form. Activating it...");
                if (lastModal.WindowState == FormWindowState.Minimized)
                    lastModal.WindowState = FormWindowState.Normal;
                lastModal.Activate();
            }
            return lastModal;
        }
