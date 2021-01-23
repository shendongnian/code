    public partial class DevExpress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dropDownOptions = new DataTable();
                dropDownOptions.Columns.Add("id");
                DataRow row = dropDownOptions.NewRow();
                row["id"] = 1;
                dropDownOptions.Rows.Add(row);
                row = dropDownOptions.NewRow();
                row["id"] = 2;
                dropDownOptions.Rows.Add(row);
                dropDownOptions.AcceptChanges();
                TrainingOptions.DataSource = dropDownOptions;
                TrainingOptions.Text = "Please choose";
                TrainingOptions.TextField = "ID";
                TrainingOptions.DataBindItems();
            }
        }
        protected void Refresh_Click(object sender, EventArgs e)
        {
            string[] parameters = { TrainingOptions.SelectedItem.Value.ToString() };
            TrainingGrid.DataSource = PopulateTrainingData(parameters);
            TrainingGrid.DataBind();
        }
        protected void TrainingOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBox ddl = (ASPxComboBox)sender;
            string[] parameters = { ddl.SelectedItem.Value.ToString() };
            TrainingGrid.DataSource = PopulateTrainingData(parameters);
            TrainingGrid.DataBind();
        }
        public DataTable PopulateTrainingData(params string[] parameters)
        {
            DataTable mainTable = (DataTable)Session["GridDT"] ?? new DataTable();
            if (!mainTable.Columns.Contains("id"))
            {
                mainTable.Columns.Add("id");
            }
            DataRow row = mainTable.NewRow();
            row["id"] = parameters[0];
            mainTable.Rows.Add(row);
            mainTable.AcceptChanges();
            HttpContext.Current.Session["GridDT"] = mainTable;
            return mainTable;
        }
    }
