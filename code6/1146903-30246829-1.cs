    private bool needToCloseApp = true;
        private void button1_Click(object sender, EventArgs e)
        {
            needToCloseApp = false;
            var childForm = new ChildForm();
            childForm.Show();
        }
        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (needToCloseApp)
            {
                Application.Exit();
            }
        }
