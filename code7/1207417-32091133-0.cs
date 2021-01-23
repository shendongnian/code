        [WebMethod]
        public static void PrintReport()
        {
            string status = "Normal";
            string Id = "40";
            string BillType = "BillReceipt";
            string Url = "BillReceipt.aspx";
            if (HttpContext.Current.CurrentHandler is Page)
            {
                Page page = (Page)HttpContext.Current.CurrentHandler;
    
                if (ScriptManager.GetCurrent(page) != null)
                {
                    ScriptManager.RegisterStartupScript(page, typeof(Page), "ApprovalHistory", "window.open('BillReceiptReport.aspx?Id=" + Id + "&Status=" + status + "&BillType=" + BillType + "&Url=" + Url + "', '_blank');", true);
                }
                else
                {
                    page.ClientScript.RegisterStartupScript(typeof(Page), "ApprovalHistory", "window.open('BillReceiptReport.aspx?Id=" + Id + "&Status=" + status + "&BillType=" + BillType + "&Url=" + Url + "', '_blank');", true);
                }
            }
        }
