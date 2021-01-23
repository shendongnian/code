    private void HandleCheckBoxCheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkBox = (CheckBox) sender;
        string imageFile;
        Color color;
        if (checkBox.Checked == true)
        {
            // TODO: Use resources embedded within your app
            imageFile = "M:\\CheckBox_52x.png";
            color = Color.Transparent;
        }
        else
        {
            imageFile = "M:\\CheckBoxUncheck_52x.png";
            color = Color.Cyan;
        }
        // TODO: Load each file once and reuse the bitmap, I suspect.
        checkBox.Image = Image.FromFile(imageFile);
        checkBox.ImageAlign = ContentAlignment.MiddleCenter;
        checkBox.FlatAppearance.BorderSize = 0;
        checkBox.BackColor = color;
        checkBox.FlatAppearance.CheckedBackColor = color;
        checkBox.FlatAppearance.MouseDownBackColor = color;
    }
