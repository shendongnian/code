    public class Animal
    {
        public int RowNumber { get; set; }
        public string Name { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Gridview1.DataSource = new List<Animal>
            {
                new Animal {RowNumber = 1, Name = "One"},
                new Animal {RowNumber = 2, Name = "Two"},
                new Animal {RowNumber = 3, Name = "Three"},
                new Animal {RowNumber = 4, Name = "Four"},
            };
            Gridview1.DataBind();
        }
    }
    
    private int _counter;
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (_counter == 0)
            {
                var linkButton = e.Row.FindControl("DeleteItemsGridRowButton") 
                    as LinkButton;
                linkButton.Visible = false;
                _counter++;
            }
        }
    
    }
