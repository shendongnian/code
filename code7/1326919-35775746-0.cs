    protected void btnSubmitOrder_Click(object sender, EventArgs e) {
         if (string.IsNullOrEmpty(lblTotalAmount.Text))
         {
               Response.Redirect("~/Default.aspx");
         }
         else
         {
               lblMessage.Text = "Please click the Calculate Order Total button first";
         }
     }
