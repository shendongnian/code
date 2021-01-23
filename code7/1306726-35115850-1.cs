    private void SetInitialRow() {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column3"] = string.Empty;
        dt.Rows.Add(dr);
    
        Table = dt;
    
        BindGrid();
        SwitchMode(false);
    }
    
    private void AddNewRowToGrid() {
        if(Table != null) {
            DataRow row = Table.NewRow();
            Table.Rows.Add(row);
            BindGrid();
            SwitchMode(false);
        }
        else {
            Response.Write("ViewState is null");
        }
    }
    
    private void SaveRow() {
        if(Table != null) {
            int rowIndex = Table.Rows.Count - 1;
            TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
            TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
            TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
            Table.Rows[rowIndex]["Column1"] = box1.Text;
            Table.Rows[rowIndex]["Column2"] = box2.Text;
            Table.Rows[rowIndex]["Column3"] = box3.Text;
            BindGrid();
            SwitchMode(true);
        }
        else {
            Response.Write("ViewState is null");
        }
    }
    
    private void SwitchMode(bool add) {
        Button saveBtn = (Button)Gridview1.FooterRow.Cells[3].FindControl("ButtonSave");
        saveBtn.Visible = !add;
        Button addBtn = (Button)Gridview1.FooterRow.Cells[3].FindControl("ButtonAdd");
        addBtn.Visible = add;
        SwitchControl(add);
    }
    
    private void SwitchControl(bool add) {
        for(int i = 0; i < Table.Rows.Count; i++) {
            bool txtVisible = false;
            if (i == Table.Rows.Count - 1) {
                txtVisible = !add;
            }
            TextBox box1 = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("TextBox1");
            box1.Visible = txtVisible;
            TextBox box2 = (TextBox)Gridview1.Rows[i].Cells[2].FindControl("TextBox2");
            box2.Visible = txtVisible;
            TextBox box3 = (TextBox)Gridview1.Rows[i].Cells[3].FindControl("TextBox3");
            box3.Visible = txtVisible;
            Label label1 = (Label)Gridview1.Rows[i].Cells[1].FindControl("Label1");
            label1.Visible = !txtVisible;
            Label label2 = (Label)Gridview1.Rows[i].Cells[2].FindControl("Label2");
            label2.Visible = !txtVisible;
            Label label3 = (Label)Gridview1.Rows[i].Cells[3].FindControl("Label3");
            label3.Visible = !txtVisible;
        }
    }
    
    private DataTable Table {
        get {
            return ViewState["CurrentTable"] as DataTable;
        }
        set {
            ViewState["CurrentTable"] = value;
        }
    }
    
    private void BindGrid() {
        Gridview1.DataSource = Table;
        Gridview1.DataBind();
    }
    
    protected void Page_Load(object sender, EventArgs e) {
        if(!Page.IsPostBack) {
            SetInitialRow();
        }
    }
    
    protected void ButtonAdd_Click(object sender, EventArgs e) {
        AddNewRowToGrid();
    }
    
    protected void ButtonSave_Click(object sender, EventArgs e) {
        SaveRow();
    }
