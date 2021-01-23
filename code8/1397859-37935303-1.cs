    protected void Button1_Click1(object sender, EventArgs e){
       Session["clickOnce"] = true;
       //more code
    }
    protected void Page_Load(object sender, EventArgs e){
       if(Session["clickOnce"] != true)
         Button1.OnClientClick = "someFunction()";
       else
         Button1.OnClientClick = "";
       //more code
    }
   
