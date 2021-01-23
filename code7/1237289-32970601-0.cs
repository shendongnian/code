    protected void btSubmit_Click(object sender, EventArgs e)
    {
        foreach (TableRow tr in t.Rows)
        {
            var tc1 = (TableCell)tr.Controls[0];
            string textboxRead= ((TextBox)tc1.FindControl("tb1")).text;
            int textboxInt = Convert.ToInt32(textboxRead);
         }
    }
