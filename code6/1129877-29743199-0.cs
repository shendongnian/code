    public partial class PaymentSearch : System.Web.UI.Page
    {
       private bool button1WasClicked
       {
           get { return (bool)Session["button1WasClicked"]; }
           set { Session["button1WasClicked"] = value; }
       }
    
       protected void linkToday_Click(object sender, EventArgs e)
       {
           button1WasClicked = true;
       }
    
      protected void ddlRecordPayment_SelectedIndexChanged(object sender, EventArgs e)
      {
          gridAllPaymentBind(1);
      }
      public void gridAllPaymentBind(int pageIndex)
      {
          if (button1WasClicked == true)
          {
             result = 3;
            command.Parameters.AddWithValue("@result", result);
          }
      }
    }
