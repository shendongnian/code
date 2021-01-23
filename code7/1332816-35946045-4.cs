    foreach (Control c in this.Controls)
    {
        if(c.GetType()==typeof(MaterialLabel))
        {
             c.Font = new Font(c.Font, FontStyle.Bold);
             c.ForeColor = Color.White;
        }
    }
