    use this..  **OnSelectedIndexChanged = "OnSelectedIndexChanged"**
    
      <asp:GridView ID="GridView1" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
            AutoGenerateColumns="false" OnSelectedIndexChanged = "OnSelectedIndexChanged">
    
    and code behind...
    
    
    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        //Accessing row
        var row = GridView1.SelectedRow;
     
        //Accessing TemplateField Column controls
        string country = (GridView1.SelectedRow.FindControl("lblCountry") as Label).Text;
     
        lblValues.Text = "<b>Name:</b> " + name + " <b>Country:</b> " + country;
    }
