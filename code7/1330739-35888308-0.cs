    GridView1.AllowPaging = false;    
    // BIND YOUR GRID HERE AGAIN
    Response.ClearContent();
	Response.Buffer = true;
	Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customers.xls"));
	Response.ContentType = "application/ms-excel";
	StringWriter sw = new StringWriter();
	HtmlTextWriter htw = new HtmlTextWriter(sw);
	       
	//Change the Header Row back to white color
	GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
	//Applying stlye to gridview header cells
	for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
	{
	GridView1.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
	}
	GridView1.RenderControl(htw);
	Response.Write(sw.ToString());
	Response.End();
