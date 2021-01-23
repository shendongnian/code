    DataClassesDataContext db = new DataClassesDataContext();
    protected DataTable GetDataSource() 
    {
    DataTable dt = new DataTable();
    var questions = db.ExecuteQuery<string>("select question from quiz where quizid is 123").ToList();
    // Header implementation
    int count = 0;
    foreach (var question in questions)
    {
        DataColumn dc = new DataColumn(question);
        dt.Columns.Add(dc);
        count++;
    }
    // Rows implementation here
    DataRow row = dt.NewRow();
    ...
    dt.Rows.Add(row);
    return dt;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    GridView1.DataSource = GetDataSource();
    GridView1.DataBind();
    }
