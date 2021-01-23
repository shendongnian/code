        private void textBoxes_TextChanged(object sender, EventArgs e)
        {
            Control ctl = (Control)sender;
            if (!String.IsNullOrEmpty(ctl.Text))
            {
                Control next = this.GetNextControl(ctl, true);
                if (next != null)
                { 
                    next.Enabled = true;
                }
            }
        }
