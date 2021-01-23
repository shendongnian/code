    private void c1TrueDBGrid1_BeforeColUpdate(object sender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs e)
    {
        if (e.ColIndex == 1)
        {
           for (int i = 0; i < c1TrueDBGrid1.RowCount; i++)
           {
            if (c1TrueDBGrid1.Editor.Text == c1TrueDBGrid1[i, e.ColIndex].ToString())
            {
                MessageBox.Show("Sorry: but this item(s) already Exists", "Error Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }
     }
    }
