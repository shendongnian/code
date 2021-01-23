        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var ctrl = e.Control as TextBox;
            if (ctrl == null) return;
            ctrl.KeyPress += Ctrl_KeyPress;
        }
        private void Ctrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check input and insert values here...
        }
