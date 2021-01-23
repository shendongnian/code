    class ConfirmButton:Button
        {
        public ConfirmButton()
        {
           
        }
        protected override void OnClick(EventArgs e)
        {
            DialogResult res = MessageBox.Show("Would you like to run the command?", "Confirm", MessageBoxButtons.YesNo
                );
            if (res == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            base.OnClick(e);
        }
    }
