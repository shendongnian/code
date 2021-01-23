    private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
    {
        pictureEdit3.Image = new Bitmap(Application.StartupPath + "/jpg/" +
                             columns[comboBoxEdit2.SelectedIndex][2].ToString() + ".jpg");
    }
