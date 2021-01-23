    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
    
            BindGrid();
        }
    
        private void BindGrid()
        {
            gvTest.Columns.Clear();
    
            var boundField = new BoundField();
            boundField.DataField = "Firstname";
            boundField.HeaderText = "First Name";
            gvTest.Columns.Add(boundField);
    
            boundField = new BoundField();
            boundField.DataField = "Lastname";
            boundField.HeaderText = "Second Name";
            gvTest.Columns.Add(boundField);
    
            var templateField = new TemplateField();
            templateField.ItemTemplate = new DayColumn();
            templateField.HeaderText = "Monday";
            gvTest.Columns.Add(templateField);
    
            DataTable dt = new DataTable();
            dt.Columns.Add("Firstname");
            dt.Columns.Add("Lastname");
    
            DataRow dr = dt.NewRow();
            dr["Firstname"] = "Test";
            dr["Lastname"] = "Test";
    
            dt.Rows.Add(dr);
    
            gvTest.DataSource = dt;
            gvTest.DataBind();
        }
    
        class DayColumn : ITemplate
        {
            public void InstantiateIn(System.Web.UI.Control container)
            {
                TextBox txtHours = new TextBox();
                txtHours.ID = "txtHours";
                txtHours.Text = "0";
                txtHours.Width = 100;
                txtHours.ValidationGroup = "Validation";
                container.Controls.Add(txtHours);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvTest.Rows.Count; i++)
            {
                TextBox txtMonday = (TextBox)gvTest.Rows[i].Cells[2].FindControl("txtHours");
            }
        }
    }
