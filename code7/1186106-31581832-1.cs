    public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
                int num = 10;
                if (Page.IsPostBack)
                {
                    
                    for (int i = 1; i < this.Repeater1.Controls.Count-1; i++)
                    {
                        RadioButton r = (RadioButton)this.Repeater1.Controls[i].Controls[3];
                        if (r.Checked)
                        {
                            num=int.Parse(r.Text.Substring(0, r.Text.IndexOf(' ')));
                            break;
                        }
                    }
                 
                }
                this.Repeater1.DataSource = GetAll(num);
                this.Repeater1.DataBind();
    
            }
    
            DataTable GetAll(int count)
            {
                Random r = new Random();
                DataTable dt = new DataTable();
                dt.Columns.Add("Text", typeof(string));
                DateTime bs = DateTime.Now;
                for (int i = 0; i < count; i++)
                {
                    int value = r.Next(3, 10);
                    dt.Rows.Add(value.ToString() + " rows will be shown");
                }
                return dt;
            }
        }
