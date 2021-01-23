    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Col1">
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenField1" Value='<%# Bind("Image") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Col2">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserName ") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="col3">
                            <ItemTemplate>
                                <asp:Panel ID="myPanelContainer" runat="server"></asp:Panel>
                               
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
----------
     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hd1 = (HiddenField)e.Row.FindControl("HiddenField1");
                Panel pnl = (Panel)e.Row.FindControl("myPanelContainer");
    
                string[] strArray = hd1.Value.Split('|');
    
                for (int i = 0; i < strArray.Length; i++)
                {
                    Image photoImageField = new Image();
                    photoImageField.ImageUrl = strArray[i];
    
                    pnl.Controls.Add(photoImageField);
                }
            }
        }
