     protected void btnReturnBack_Click(object sender,EventArgs e)
     {
          //Code for whatever you want to done here
          if(Session["ReturnURL"] != null)
          {
               Response.Redirect(Convert.ToString(Session["ReturnURL"]), true);
          }
     }
