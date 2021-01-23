    private void dataGridView1_SortCommand(object source, 
    System.Web.UI.WebControls.dataGridView1SortCommandEventArgs e)
    {
       dataGridView1.Sort = e.SortExpression;
       dataGridView1.DataBind();
    }
