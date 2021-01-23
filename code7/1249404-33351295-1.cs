    private void Page_Init(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["dataset"];
            String query = ""
            if(Session["query"]!= null){
                query = (String)Session["query"];
            }
            if (dt == null)
            {
                System.Diagnostics.Debug.WriteLine("THIS IS A TEST EVENT MESSAGE Response Header----------- THIS IS A TEST EVENT MESSAGETHIS IS A TEST EVENT MESSAGETHIS IS A TEST EVENT MESSAGETHIS IS A TEST EVENT"); ;
            }
            GenerateReport(dt);
        }
