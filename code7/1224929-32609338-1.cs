    protected void Page_Load(object sender, EventArgs e)
    {
    
        if (!Page.IsPostBack)
        {
            // Create a new table.
            DataTable taskTable = new DataTable("TaskList");
    
            // Create the columns.
            taskTable.Columns.Add("Id", typeof(int));
            taskTable.Columns.Add("Description", typeof(string));
            taskTable.Columns.Add("IsComplete", typeof(bool));
    
            //Add data to the new table.
            for (int i = 0; i < 20; i++)
            {
                DataRow tableRow = taskTable.NewRow();
                tableRow["Id"] = i;
                tableRow["Description"] = "Task " + i.ToString();
                tableRow["IsComplete"] = false;
                taskTable.Rows.Add(tableRow);
            }
    
            //Persist the table in the Session object.
            Session["TaskTable"] = taskTable;
    
            //Bind data to the GridView control.
            BindData();
        }
    }
    
    protected void TaskGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Retrieve the table from the session object.
        DataTable dt = (DataTable)Session["TaskTable"];
    
        //Update the values.
        GridViewRow row = TaskGridView.Rows[e.RowIndex];
        dt.Rows[row.DataItemIndex]["Id"] = ((TextBox)(row.Cells[1].Controls[0])).Text;
        dt.Rows[row.DataItemIndex]["Description"] = ((TextBox)(row.Cells[2].Controls[0])).Text;
        dt.Rows[row.DataItemIndex]["IsComplete"] = ((CheckBox)(row.Cells[3].Controls[0])).Checked;
    
        //Reset the edit index.
        TaskGridView.EditIndex = -1;
    
        //Bind data to the GridView control.
        BindData();
    }
    
    private void BindData()
    {
        TaskGridView.DataSource = Session["TaskTable"];
        TaskGridView.DataBind();
    }
