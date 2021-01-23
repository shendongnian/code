    public void CountIt()
    {
        foreach (CheckBox box in flw.Controls.OfType<CheckBox>())
        {
            if (box.Checked)
            {
                count++;
            }
        }
        MessageBox.Show(count.ToString());
    }
