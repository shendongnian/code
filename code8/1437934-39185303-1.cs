    // This is not absolutely necessary, but you may want to include it
    using System.Web.UI.HtmlControls;
      protected void Page_PreInit(object sender, EventArgs e)
      {
        StringWriter strWtr;
        StringBuilder sbldr;
        HtmlTextWriter htmlWtr;
        
        // Put in table modifying code here
        this.tbl_Mine.Rows[0].ID = "r1";
        this.tbl_Mine.Rows[0].Cells[0].ID = "r1c1";
        sbldr = new StringBuilder();
        strWtr = new StringWriter(sbldr);
        htmlWtr = new HtmlTextWriter(strWtr);
    
        this.tbl_Mine.RenderControl(htmlWtr);
        File.WriteAllText(@"C:\Temp\HtmlTblMod.htm", sbldr.ToString());
      }
