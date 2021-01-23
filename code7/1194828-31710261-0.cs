    <asp:Repeater runat="server" ID="repeat" OnItemDataBound="repeat_ItemDataBound">
        <ItemTemplate>
            <asp:Label ID="lbl" runat="server" />
        </ItemTemplate>
    </asp:Repeater>
        public partial class _Default : Page
        {
            int count = 0;
            protected void Page_Load(object sender, EventArgs e)
            {
                string[] answers = new string[10] { "Y", "Y", "N", "Y", "N", "Y", "N", "Y", "N", "Y" };
                repeat.DataSource = answers;
                repeat.DataBind();
            }
    
        protected void repeat_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            count++;
            var lbl = e.Item.FindControl("lbl") as Label;
    
            lbl.Text = string.Format("Question {0} <br />{1}<br />",count.ToString(), e.Item.DataItem.ToString());
        }
    }
