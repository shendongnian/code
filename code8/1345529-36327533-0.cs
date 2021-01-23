     <form id="form1" runat="server">
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Job" HeaderText="Job" />
                        <asp:BoundField DataField="Location" HeaderText="Location" />
                        <asp:ImageField DataImageUrlField="Image" HeaderText="Image">
                        </asp:ImageField>
                    </Columns>
                
                </asp:GridView>
            </div>
            
            <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
            </form>
    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    GridView1.DataSource = GetTable();
                    GridView1.DataBind();
                }
            }
            static DataTable GetData()
            {
                DataTable table = new DataTable();
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Job", typeof(string));
                table.Columns.Add("Location", typeof(string));
                table.Columns.Add("Image");
    
                table.Rows.Add("JP", "XXX", "QQQQ", "http://localhost:4832/images/JP.png");
                table.Rows.Add("HP", "TTT", "AAAA", "http://localhost:4832/images/HP.png");
                table.Rows.Add("SQ", "YYY", "HHHH", "http://localhost:4832/images/SQ.png");
                table.Rows.Add("XS", "EEE", "UUUU", "http://localhost:4832/images/XS.png");
                return table;
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=test.xls");
                Response.ContentType = "application/excel";
                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                GridView1.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();
            }
            public override void VerifyRenderingInServerForm(Control control)
            {
                
            }
