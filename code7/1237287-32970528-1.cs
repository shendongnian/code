    TextBox tb1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            tb1 = ((TextBox)r.FindControl("tb1"));                
        }
    }
    protected void btSubmit_Click(object sender, EventArgs e)
    {
         string textboxRead = tb1.Text; // here you can get the tb1.Text
         int textboxInt = Convert.ToInt32(textboxRead);
    }
