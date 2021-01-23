    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                  DataTable dt = new DataTable();
                  dt.Columns.Add("val", typeof(string));
              
                for (int i = 0; i < 10; i++)
                  dt.Rows.Add("testing" + i.ToString());
           
           Repeater1.DataSource = dt;
           Repeater1.DataBind();
               }
            }     
    
        protected void Button2_Click(object sender, EventArgs e)
                {
                    string Rpt = "Repeater Items Checked:<br />";
                    for (int i = 0; i < Repeater1.Items.Count; i++)
                    {
                        CheckBox chk = (CheckBox)Repeater1.Items[i].FindControl("CategoryID");
                        if (chk.Checked)
                        {
                            Rpt += (chk.Text + "<br />");
                        }
                    }
                    Response.Write(Rpt);
                }
