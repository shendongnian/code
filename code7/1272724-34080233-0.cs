    public string ValueIWant { get; set; }
    private void btnSetValueIWant_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtbxValue.Text))
        {
            ValueIWant= txtbxValue.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
