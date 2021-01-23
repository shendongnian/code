    private void btnEdit_Click(object sender, EventArgs e)
    {
        btnEdit.Visible = false;
        btnPrint.Visible = false;
        btnSave.Visible = true;
        //Want to call mouse function here.
        textBox.MouseDown += new MouseEventHandler(textBox_MouseDown);
    }
