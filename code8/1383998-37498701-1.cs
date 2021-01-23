     public class PersonT
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string CreditRequest { get; set; }
        }
    
        public partial class aaaa_GridViewRowUpdating : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    this.BindData();
                }
            }
    
            private void BindData()
            {
                var p1 = new PersonT() { ID = 10, Name = "Person 1", CreditRequest = "Credit Request 1" };
                var p2 = new PersonT() { ID = 20, Name = "Person 2", CreditRequest = "Credit Request 2" };
    
                var list = new List<PersonT> { p1, p2 };
                GridView1.DataSource = list;
                GridView1.DataBind();
            }
    
            protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
            {
                GridView1.EditIndex = e.NewEditIndex;
                BindData();
            }
    
            protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
                System.Diagnostics.Debugger.Break();
                int index = e.RowIndex;
                int DataKeyValue = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString());
            }
    
            protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
            {
                GridView1.EditIndex = -1;
                BindData();
            }
        }
