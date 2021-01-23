    private void ToolTipControl_Load(object sender, EventArgs e)
        {
            AttachHandlers(this);
        }
        private void AttachHandlers(Control currentControl)
        {
            foreach (Control control in currentControl.Controls)
            {
                control.MouseHover += GenericMouseHover;
                control.MouseLeave += GenericMouseLeave;
                if (control.Controls.Count != 0)
                {
                    AttachHandlers(control);
                }
            }
        }
        void GenericMouseLeave(object sender, EventArgs e)
        {
            // no need to hide it if there was no form created in first place
            if(_form != null && _form.Visible)
            Form.Hide();
        }
        private void GenericMouseHover(object sender, EventArgs e)
        {
            Form.Location = this.PointToClient(Cursor.Position);
            Form.Show();
        }
        ToolTipForm _form;
        private ToolTipForm Form
        {
            get
            {
                if (_form == null)
                {
                    _form = new ToolTipForm();
                }
                return _form;
            }
        }
