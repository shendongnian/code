        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && (Control.Modifiers & Keys.Control) == Keys.Control)
            {
                StripEmptyFromCopy();
                e.Handled = true;
            }
        }
