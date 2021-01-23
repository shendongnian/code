    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<DataRow> lstData { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadgrid();
        }
        public void loadgrid()
        {
            DataTable dt = GetTable();
            List<DataRow> lstCollection = dt.AsEnumerable().ToList();
            lstData=lstCollection;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        static DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("ZipCode", typeof(string));
            // Here we add five DataRows.
            for (int i=1; i<=100 ; i++)
            {
             table.Rows.Add(i, "Z00"+i);
            }
           
            return table;
        }
        public void SearchResult(string SearchParameter)
        {
            if (lstData != null)
            {
                if (SearchParameter != "")
                {
                    if (lstData != null)
                    {
                      List<DataRow> dt2 = lstData.FindAll(a=>a.ItemArray[0].ToString()== SearchParameter || a.ItemArray[1].ToString().ToLower() == SearchParameter.ToLower());
                      GridView1.DataSource = dt2.CopyToDataTable();
                      GridView1.DataBind();
                    }
                }
                else
                {
                    lstData = null;
                    loadgrid();
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
                string SearchText = TextBox1.Text.ToString().Trim();
                SearchResult(SearchText);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            lstData = null;
            loadgrid();
        }
    }
