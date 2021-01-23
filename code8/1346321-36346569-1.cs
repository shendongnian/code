    public class MyComboBox : ComboBox
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                this.SelectedIndex= this.FindString(this.Text);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
