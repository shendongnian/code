    void Page_Load(Object sender, EventArgs e)
      {
        // Manually register the event-handling method for the   
         // CheckedChanged event of the CheckBox control.
         checkbox1.CheckedChanged += new EventHandler(this.Check_Clicked);
      }
    void Check_Clicked(Object sender, EventArgs e) 
      {
      **//This is only sample code**
        // do your code
        if (panel2.Visible) 
        {
        panel2.Visible = false;
        cmdAdvanced.Visible = true;
        }
       }
