     public partial class WebForm1 : System.Web.UI.Page
    {
        List<Column> Columns = new List<Column>();
        protected void Page_Init(object sender, EventArgs e)
        {
            Columns.Add(new Column { ColumnName = "ID" });
            Columns.Add(new Column { ColumnName = "Name" });
            Columns.Add(new Column { ColumnName = "Surname" });
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = Columns;
            Repeater1.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> Values = new Dictionary<string, string>();
            foreach (var item in Columns)
            {
                Values.Add(item.ColumnName, Request.Form[item.ColumnName]);
            }
        }
    }
    class Column
    {
        public string ColumnName { get; set; }
    }
