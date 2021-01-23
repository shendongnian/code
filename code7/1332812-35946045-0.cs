    foreach (Control c in this.Controls)
    {
        if(c.GetType()==typeof(MaterialLabel))
        {
             //item.Font.Size = 11f;
             c.ForeColor = Color.White;
        }
    }
