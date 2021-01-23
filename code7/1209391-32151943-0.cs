    <asp:Repeater ID="repeaterBlog" runat="server" OnItemDataBound="repeaterBlog_ItemDataBound">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:HiddenField ID="hide" Value='<%#Eval("UserId")%>' runat="server" />
                    <asp:TextBox ID="txtReplyArea" runat="server" TextMode="Multiline" Columns="70" Rows="8"
                        Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="margin-left: 47%;">
                    <asp:Button ID="btnReply" runat="server" Text="Reply" OnClick="btnReplyClicked" AutoPostBack="True"
                        CommandArgument='<%#Eval("UserId")%>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserId");
            DataRow dr = dt.NewRow();
            dr[0] = 34;
            dt.Rows.Add(dr);
            repeaterBlog.DataSource = dt;
            repeaterBlog.DataBind();
        }
        public void repeaterBlog_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                TextBox txt = (TextBox)e.Item.FindControl("txtReplyArea");
                HiddenField hf = (HiddenField)e.Item.FindControl("hide");
                txt.ID = "txtReplyArea" + hf.Value;
            }
        }
        protected void btnReplyClicked(object sender, EventArgs e)
        {
            int areaId = int.Parse((sender as Button).CommandArgument);
            string id = "txtReplyArea" + areaId;
            foreach (RepeaterItem item in repeaterBlog.Items)
            {
                TextBox tb = item.FindControl(id) as TextBox;
            }
        }
