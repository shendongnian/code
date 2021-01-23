    foreach (GridViewRow row in GridView1.Rows)
    {    
        TextBox box1 = row.FindControl("TBID") as TextBox;
        if (box1 != null)
        {
            string value = box1.Text;
        }
     }
