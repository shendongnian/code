    public void ChangBackColor_Click(object sender, EventArgs e)
    {
        if (ColorDialog.ShowDialog() == DialogResult.OK)
        {
            //Access Form1's reference with _ParentForm instead of Form1
            _ParentForm.ChangeBack(ColorDialog.Color);
        }
    }
