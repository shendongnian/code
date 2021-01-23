     protected void Page_Load(object sender, EventArgs e){
         if (IsPostBack){ //confirms it's a PostBack and not initial load
            Button myButton = (Button)(sender as Page).FindControl("button_Search"); //find your button
            if (myButton.ID == "button_Search"){
                // your normal code (the code you intend in button_Search_Click )goes here...
            }
         }
     }
