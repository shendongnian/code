    public static void UpdateSerialQtyRcvd(System.Web.UI.Page pg, int qtyRcvd)
    {
         if (qtyRcvd != 1)
         {
              //if (SerNo.Reason == "")
              //{
                    pg.ClientScript.RegisterStartupScript(pg.GetType(), "alert", "<script>alert('Message');</script>");
              //}
         }
    }
