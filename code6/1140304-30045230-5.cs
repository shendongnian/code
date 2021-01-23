    public partial class TreeView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        public string GetTreeViewJson()
        {
            return JsonConvert.SerializeObject(GetTreeView());
        }
    
        public IEnumerable<CategoryRootTreeModel> GetTreeView()
        {
            List<CategoryRootTreeModel> items = new List<CategoryRootTreeModel>();
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlCommand = new SqlCommand("SELECT * FROM [dbo].[Category_Tbl]", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
    
                sqlConnection.Open();
    
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new CategoryRootTreeModel
                        {
                            catid = (int)reader["ID"],
                            expanded = true,
                            text = reader["Categories"].ToString()
                        });
                    }
                }
            }
            items.ForEach(item => bindSubCategeories(item));
            return items;
        }
    
        void bindSubCategeories(CategoryRootTreeModel model)
        {
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var sqlCommand = new SqlCommand("SELECT * FROM [dbo].[SubCategory_Tbl] WHERE CATID = @p0", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@p0", model.catid);
    
                sqlConnection.Open();
    
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        model.items.Add(new CategoryTreeItemModel
                        {
                            catid = (int)reader["ID"],
                            subcatid = (int)reader["CATID"],
                            text = reader["Subcategories"].ToString()
                        });
                    }
                }
            }
        }
    
    
    
    }
    
    public class CategoryRootTreeModel
    {
        public CategoryRootTreeModel()
        {
            this.items = new List<CategoryTreeItemModel>();
        }
    
        public string text { get; set; }
    
        public bool expanded { get; set; }
    
        public int catid { get; set; }
    
        public List<CategoryTreeItemModel> items { get; set; }
    }
    
    public class CategoryTreeItemModel
    {
        public string text { get; set; }
    
        public int catid { get; set; }
    
        public int subcatid { get; set; }
    }
