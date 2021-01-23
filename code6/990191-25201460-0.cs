    <asp:SqlDataSource ID="SqlDataSource1"  runat="server" ConnectionString="Data Source=*******Initial Catalog=*******;Persist Security Info=True;User ID=*******;Password=*******" ></asp:SqlDataSource>
    <div>
        <asp:TextBox ID="SqlQueryTextBox" runat="server" ></asp:TextBox>
        <asp:Button ID="ExecuteButton"  OnClick="ExecuteButton_Click" runat="server" Text="Execute"/>
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="true" />
    </div>
..
    protected void ExecuteButton_Click(object sender, EventArgs e)
    {
    SqlDataSource1.SelectCommand = SqlQueryTextBox.Text;
    GridView1.DataBind();
    }
