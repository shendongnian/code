    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack == true)
                {
                    Session["button1WasClicked "] = false;
    }
    }
       
       
       protected void linkToday_Click(object sender, EventArgs e)
       {
           Session["button1WasClicked "] = true;
        }
        
      protected void ddlRecordPayment_SelectedIndexChanged(object sender, EventArgs e)
      {
      gridAllPaymentBind(1);
      }
       public void gridAllPaymentBind(int pageIndex)
       {
    bool button1WasClicked = (bool)Session["button1WasClicked "];
       if (button1WasClicked == true)
      {
       result = 3;
        command.Parameters.AddWithValue("@result", result);
       }
     
     }
