    public void CountIt()
    {
        foreach (CheckBox box in groupBox.Controls.OfType<CheckBox>())
        {
            if (box.Checked)
            {
                count++;
            }
        }
        MessageBox.Show(count.ToString());
    }
