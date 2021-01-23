    public void ExportGridToExcel2()
    {
          Response.Clear();
          Response.Buffer = true;
          Response.ClearContent();
          Response.ClearHeaders();
          Response.Charset = "";
    
          string FileName ="Export"+DateTime.Now+".xls";
    
          StringWriter strwritter = new StringWriter();
          HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
    
          Response.Cache.SetCacheability(HttpCacheability.NoCache);
          Response.ContentType = "application/vnd.ms-excel";
          Response.AddHeader("Content-Disposition","attachment;filename=" + FileName);
    
          GridView2.GridLines = GridLines.Both;
          GridView2.HeaderStyle.Font.Bold = true;
          GridView2.RenderControl(htmltextwrtter);
    
          Response.Write(strwritter.ToString());
          Response.End();
    }
