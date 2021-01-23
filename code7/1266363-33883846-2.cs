    <asp:TemplateField HeaderText="Action3" Visible="false">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
     <ItemTemplate>
    <asp:LinkButton ID="lnkretqty" runat="server" Text="Return Qty" CommandName="RETQTY" ToolTip="Click here to Add Return Qty Entry"
     CommandArgument='<%# Container.DataItemIndex %>'>
    </asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    Code Behind code
    
    protected void gvsearch_RowCommand(object sender, GridViewCommandEventArgs e)
     {
     try
     {
     if (e.CommandName == "SRCSELREC")
     {
    Int32 rowind = Convert.ToInt32(e.CommandArgument.ToString());
    string val = ((Label)gvgpitemdtl.Rows[rowind].FindControl("d")).Text.ToString();
    
    
     }
    }
    catch (Exception ex)
     {
     General.MessageBox(this.Page, "Error at Gridview Row Command : " + ex.Message.ToString());
     return;
     }
    }
