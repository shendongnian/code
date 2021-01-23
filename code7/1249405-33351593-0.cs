    private void Page_Init(object sender, EventArgs e) {
        DataTable dt;
        String query = "";
        if (Session["query"] != null) {
            query = (String)Session["query"];
        }
        if (Session["dataset"] != null) {
            dt = (DataTable)Session["dataset"];
            GenerateReport(dt);
        }
        else {
            System.Diagnostics.Debug.WriteLine("THIS IS A TEST EVENT MESSAGE Response Header----------- THIS IS A TEST EVENT MESSAGETHIS IS A TEST EVENT MESSAGETHIS IS A TEST EVENT MESSAGETHIS IS A TEST EVENT"); ;
        }
    }
