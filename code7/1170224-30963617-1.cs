    <asp:Button Text="text" runat="server" OnClick="Unnamed_Click" />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ReportId" Width="100%"
                ForeColor="#333333" PageSize="5" Style="text-align: center">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBoxG1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridView1.DataSource = new RowModel[]
                {
                    new RowModel { ReportId = "1" },
                    new RowModel { ReportId = "2" },
                    new RowModel { ReportId = "3" }
                };
                GridView1.DataBind();
            }
        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox CheckRow = (row.Cells[0].FindControl("CheckBoxG1") as CheckBox);
                    if (CheckRow.Checked)
                    {
                    }
                }
            }
        }
    public class RowModel
    {
        public string ReportId { get; set; }
    }
