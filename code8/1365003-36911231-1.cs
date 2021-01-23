        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var mockData = new[] {"1", "1", "2", "1", "3", "2"};
                GridView1.DataSource = mockData;
                GridView1.DataBind();
            }
        }
      
        protected void CheckBox1_Click(object sender, EventArgs e)
        {
            var chkBox = (CheckBox) sender;
            var selectedRow = chkBox.Parent.Parent;
            var itemValue = ((GridViewRow)selectedRow).Cells[1].Text; 
            
            foreach (var chkItem in GridView1.Rows.Cast<GridViewRow>()
                .Where(item => item.Cells[1].Text == itemValue)
                .Select(item => item.Cells[0].FindControl("CheckBox1")).OfType<CheckBox>())
            {
                chkItem.Checked = chkBox.Checked;
            }
        }
    }
