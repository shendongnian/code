    protected void ExportToExcel(object sender, EventArgs e)
        {
          try
          {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("contentdisposition","attachment;filename=Demo.xls");
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);
            Label lblheader = new Label();
            lblheader.Font.Size = 14;
            lblheader.Font.Bold = true;
            lblheader.Text = "Demo Detail";
            lblheader.RenderControl(hw);
        
            GrdExcel.Visible = true;
            GrdExcel.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
            GrdExcel.Visible = false;
        }
        catch (Exception ex)
        {
        
        }
    
    }
