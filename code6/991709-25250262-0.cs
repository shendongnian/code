    <asp:GridView ID="GridView1" runat="server"
        AutoGenerateColumns="False"
        EnableModelValidation="True"
        OnRowEditing="GridView1_RowEditing">
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //Set the edit index.
        GridView1.EditIndex = e.NewEditIndex;
        //Bind data to the GridView control.
        BindData();
    }
