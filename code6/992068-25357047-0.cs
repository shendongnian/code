    protected string tdate { get; set; }
    
     protected void Page_Load(object sender, EventArgs e)
        {
           this.tdate = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
        }
