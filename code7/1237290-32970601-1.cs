    protected void btSubmit_Click(object sender, EventArgs e)
    {
        foreach (TableRow tr in t.Rows)
        {
            var tc1 = (TableCell)tr.FindControl("tc1");
            var tb1 = (TextBox)tc1.FindControl("tb1");
            int textboxInt = Convert.ToInt32(tb1.Text);
         }
    }
