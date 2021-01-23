        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var confirmation = MessageBox.Show("Sure to close form", "Confirm", MessageBoxButtons.YesNo);
            if (confirmation == System.Windows.Forms.DialogResult.No)
            {
                 e.Cancel = true; //Even cancelled, form will not get closed now
            }
        }
