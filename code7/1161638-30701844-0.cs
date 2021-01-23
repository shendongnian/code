      protected void gvData_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
       {
	     if (e.Row.RowType == DataControlRowType.DataRow) {
		   e.Row.Cells(0).Width = new Unit("200px");
		   e.Row.Cells(1).Width = new Unit("500px");
	   }
      }
