     private void bPickColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = false;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
      
                Color c = colorDlg.Color;
                _ColorName = GetColorName(c);
                MessageBox.Show(_ColorName);
                bPickColor.BackColor = colorDlg.Color;
            }
        }
