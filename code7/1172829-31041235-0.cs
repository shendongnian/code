    public static string id="";
    public void RunStoreProcedure()
    {
        string ID = "123456";
        id=ID;
    }
    protected void btn_Click(object sender, EventArgs e)
            {           
                Response.AddHeader("content-disposition", "attachment;filename="+ id +".doc");
             }
