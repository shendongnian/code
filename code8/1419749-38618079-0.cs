    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request["download"]=="1")
        {
            Response.ContentType = "html/text";
            Response.AddHeader("Content-Disposition", "attachment; filename=file.txt");
            Response.Write("content of the file");
            Response.Flush();
            Response.Close();
            Response.End(); 
        }
    }
