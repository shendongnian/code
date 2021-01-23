    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
     //Accessing BoundField Column
     string name = GridView1.SelectedRow.Cells[0].Text;
 
     //Accessing TemplateField Column controls
     string country = (GridView1.SelectedRow.FindControl("lblCountry") as Label).Text;
 
     lblValues.Text = "<b>Name:</b> " + name + " <b>Country:</b> " + country;
    }
