    protected void Page_Load(object sender, EventArgs e)
    {
       Label1.Text = "";
       System.Threading.Thread.Sleep(5000);  //Wait for 5 seconds before displaying 'name1'
       Label1.Text = "name1";
       System.Threading.Thread.Sleep(5000); //Wait another 5 seconds before displaying 'name2'
       Label1.Text = "name2";
    }
