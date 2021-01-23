        private void dataGridView1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control) {
                // etc...
                e.Handled = true;
            }
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control) {
                // etc...
                e.Handled = true;
            }
        }
