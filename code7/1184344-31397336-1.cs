    protected void RGGSTAcCode_ItemDataBound(object sender, GridItemEventArgs e)
        {
    
           if (e.Item is GridEditableItem && e.Item.IsInEditMode)
                {
                    //bind dropdwon while "Add" 
                    string CompanyCode = ddlCompany.SelectedValue.ToString();
                    GridEditableItem item = (GridEditableItem)e.Item;
                    DropDownList ddl = (DropDownList)item.FindControl("ddlAcCode");
                    ddl.DataSource = GetAccCode(CompanyCode);
                    ddl.DataTextField="*your text field*";
                    ddl.DataValueField="*your Value field*";
                    ddl.DataBind();
                    ddl.Items.Insert(0, "- Select -");
    
                   Label lblAcCode2 = item.FindControl("lblAcCode2") as Label;
                   if (!string.IsNullOrEmpty(lblAcCode2.Text))
                   {
                      ddl.SelectedItem.Text = lblAcCode2.Text;
                      ddl.SelectedValue = lblAcCode2.Text;
                   }
               }
         }
        <telerik:GridTemplateColumn UniqueName="AccountCode" HeaderText="Account Code">
           <ItemTemplate>
             <asp:Label ID="lblAcCode" runat="server" Text='<%# Eval("AccountCode")%>'></asp:Label>
           </ItemTemplate>
           <EditItemTemplate>
             <asp:Label ID="lblAcCode2" runat="server" Text='<%# Eval("AccountCode") + " - " + Eval("AccountDescription")%>' Visible="false"></asp:Label>
             <asp:DropDownList ID="ddlAcCode" DataTextField="AccountDescription" DataValueField="AccountCodeID" runat="server"/> 
           </EditItemTemplate>
       </telerik:GridTemplateColumn>
