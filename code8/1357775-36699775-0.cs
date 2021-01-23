        protected void Page_Load(object sender, EventArgs e)
    {
            HttpCookie mycookie = Request.Cookies["info"];
        if(mycookie!=null)
        TextBox1.Text=mycookie.Value;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        HttpCookie mycookie= new HttpCookie("info");
        mycookie.Expires = DateTime.Now.AddDays(3);
        mycookie.Value=TextBox1.Text;
        Response.Cookies.Add(mycookie);
    }
