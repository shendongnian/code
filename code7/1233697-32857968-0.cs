    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dCol1 = new DataColumn("Col1", typeof(System.String));
            DataColumn dCol2 = new DataColumn("Col2", typeof(System.String));
            dt.Columns.Add(dCol1);
            dt.Columns.Add(dCol2);
            for (int i = 0; i < 2; i++)
            {
                DataRow row1 = dt.NewRow();
                row1["Col1"] = "One";
                row1["Col2"] = "Two";
                dt.Rows.Add(row1);
            }
            foreach (DataColumn col in dt.Columns)
            {
                BoundField bField = new BoundField();
                bField.DataField = col.ColumnName;
                bField.HeaderText = col.ColumnName;
                GridView1.Columns.Add(bField);
            }
            GridView1.DataSource = dt;
            //Bind the datatable with the GridView.
            GridView1.DataBind();
            string str = GridView1.Rows[0].Cells[0].Text;
        }
    }
