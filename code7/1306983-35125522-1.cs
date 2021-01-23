     public partial class PODetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(Helper.GetCon());
    
        protected void Page_Load(object sender, EventArgs e)
        {
    
            if (!IsPostBack)
            {
                AddProducts();
    
            }
        }
    
        void AddProducts()
        {
            DataTable dt = new DataTable();
            dt.TableName = "PurchaseDetails";
            //creating columns for DataTable  
            dt.Columns.Add(new DataColumn("PurchaseNo", typeof(int)));
            dt.Columns.Add(new DataColumn("ProductID", typeof(int)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(int)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(decimal)));
    
            ViewState["PurchaseDetails"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    
    
        void AddNewRecordRowToGrid()
        {
            if (ViewState["PurchaseDetails"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["PurchaseDetails"];
                DataRow drCurrentRow = null;
                drCurrentRow = dtCurrentTable.NewRow();
                drCurrentRow["Name"] = Name.Text;
                drCurrentRow["Quantity"] = Convert.ToInt32(Quantity.Text);
                drCurrentRow["Price"] = Convert.ToDecimal(Price.Text);
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["PurchaseDetails"] = dtCurrentTable;
                GridView1.DataSource = dtCurrentTable;
                GridView1.DataBind();
            }
        }
        void BulkInsertToDataBase()
        {
        }
        protected void AddProduct_Click(object sender, EventArgs e)
        {
            AddNewRecordRowToGrid();
        }
        protected void btnsubmitProducts_Click(object sender, EventArgs e)
        {
            BulkInsertToDataBase();
        }
    }
