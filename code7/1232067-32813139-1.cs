    <asp:Repeater ID="RepeaterReport" ItemDataBound="RepeaterReport_ItemDataBound" runat="server">
      <ItemTemplate>
          <a id="myAnchor" runat="server" href="../mentor/report.aspx?like=<%# Eval("IdBesked") %>" class="btn btn-success mr-xs mb-sm">
            <i class="fa fa-thumbs-up"></i>Synes godt om
          </a>
       </ItemTemplate>
    </asp:Repeater>
---
    public void RepeaterReport_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "like")) != true)
            {
                ((HtmlControl)e.Item.FindControl("myAnchor")).Visible = false;
            }
        }
    }
