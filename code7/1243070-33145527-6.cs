    public partial class _Default : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
        List<employee> obj = new List<employee>() { 
                new employee(1, "Sunny1"), 
                new employee(2, "Sunny2"), 
                new employee(3, "Sunny3"), 
                new employee(4, "Sunny4"), 
                new employee(5, "Sunny5"), 
                new employee(6, "Sunny6"), 
                new employee(7, "Anny7")};
        DataGrid1.DataSource = obj;
        DataGrid1.DataBind();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Changetext();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Changetext();
    }
    private void Changetext()
    {
        string str = DropDownList1.SelectedItem.ToString() + " ";
        str += DropDownList2.SelectedItem.ToString();
        if (DataGrid1.Rows.Count > 0)
        {
            for (int i = 0; i < DataGrid1.HeaderRow.Cells.Count; i++)
            {
                DataGrid1.HeaderRow.Cells[i].Text =   DataGrid1.HeaderRow.Cells[i].Text + " " + str; //selectedvalue / text;
              
            }
        }
    }
    }
