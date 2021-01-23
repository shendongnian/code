    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);
        if(BackButtonClicked)
        {
          //code used for DialogResult.No answer
          BackButtonClicked = false;
        }
         if (e.CloseReason == CloseReason.UserClosing) 
         {
            //Some Code
         }
    }
        public bool BackButtonClicked { get; set; }
     private void backButton_Click(object sender, EventArgs e)
            {
              //Some code
              BackButtonClicked = true;
              //Some code, close form
            } 
