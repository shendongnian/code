    <telerik:GridTemplateColumn>
           <ItemTemplate>
              <asp:LinkButton ID="btnDownload" OnClick="btnDownload_Click" runat="server">Download Something</asp:LinkButton>
            </ItemTemplate>
       </telerik:GridTemplateColumn>
    protected void btnDownload_Click(object sender, EventArgs e)
    {
      LinkButton lbBtn = sender as LinkButton;
      GridDataItem item = (GridDataItem)(sender as LinkButton).NamingContainer;
      // Use item to get other details
    ...
    ...
    }
