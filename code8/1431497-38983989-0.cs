        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                // Make sure form is visible before closing //
                form.Show();
                form.Close();
            }
            Environment.Exit(0);
        }
