    protected void Page_Load(object sender, EventArgs e)
            {
               UpdateSerialQtyRcvd(SerNoID, QtyRcvd,Page);
            }
 
    public static void UpdateSerialQtyRcvd(int SerNoID, int QtyRcvd,Page page)
      {
         if (SerNo.QtyRcvd != 1)
           {
                if (SerNo.Reason == "")
                {
                 page.ClientScript.RegisterStartupScript(page.GetType(),"alert", "<script>alert('Hai');</script>");
                }
            }
        
       }
