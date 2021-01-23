     <asp:GridView ID="GridView1" runat="server" AllowPaging="True"   PageSize="20" 
        onpageindexchanging="GridView1_PageIndexChanging"
        onrowcommand="GridView1_RowCommand" AutoGenerateColumns="False" 
        onrowdatabound="GridView1_RowDataBound"> 
    </asp:GridView>
    private void BuildResults()
    {
    DataTable dt01 = obSectionDefinition.List(_criteria.AuditDefinitionGUID, _criteria.ParentGUID, _criteria.ShowObsolete);
    
    // GridView1.PageSize = 20;
    // ViewState["dt_data"] = dt01;
     GridView1.DataSource = dt01;
     GridView1.DataBind();
    }
    
    
    public void GridView1_PageIndexChanging(object  sender,GridViewPageEventArgs e)
    {
         GridView1.PageIndex = e.NewPageIndex;
        BuildResults();
    }
