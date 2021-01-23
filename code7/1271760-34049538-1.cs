    private void button2_click (object sender, EventArgs e)
    {
    // Find control on page.
          Control myControl1 = FindControl("textBox1");
          if(myControl1 != null)
          {
             // Get control's parent.
            TextBox textBox1 = (myControl1 as TextBox);
            if (textBox1 != null && string.IsNullOrWhiteSpace(textBox1.Text))
            {
              /*code*/;
            }
             Response.Write("Parent of the text box is : " + myControl1.ID);
          }
          else
          {
             Response.Write("Control not found");
          }
    //...
