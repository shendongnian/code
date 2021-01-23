     //Declaring datatable 
     DataTable dt = new DataTable();
     //storing datatable into session in this way
        Session.Add("emp", dt);
      //acessing in that way
        DataTable employee= Session["emp"] as DataTable
