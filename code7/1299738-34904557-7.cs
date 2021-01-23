     protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    DataClasses1DataContext db = new DataClasses1DataContext();
                    var data = db.Departments.ToList();
    
                    ParentGridView.DataSource = data;
                    ParentGridView.DataBind();
                }
            }
    
            protected void ParentGridView_SelectedIndexChanged(object sender, EventArgs e)
            {
                int key = int.Parse(ParentGridView.SelectedDataKey.Value.ToString());
    
                DataClasses1DataContext db = new DataClasses1DataContext();
                var data = db.Categories.Where(p => p.DepartmentId == key);
    
                ChildGridView.DataSource = data;
                ChildGridView.DataBind();
            }
