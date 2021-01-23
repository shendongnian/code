        int lines = Convert.ToInt32(txtLines.Text);
        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j <= i; j++) {
                rTxtOutputD2.Text += "#";
            }
            rTxtOutputD2.Text += "\n";
        }
        for (int i = lines; i > 0; i--)
        {
            for (int j = 0; j < i; j++) {
                rTxtOutputD2.Text += "#";
            }
            rTxtOutputD2.Text += "\n";
        }
        
