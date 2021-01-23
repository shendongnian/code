        DateTime LastPressed = DateTime.Now;
        
        private MyControl_KeyDown(object sender, KeyEventArgs e)
             if(e.Shift){
                  if((DateTime.Now-LastPressed).TotalMilliSeconds< 400){ 
    //if gap between two clicks are less than 400 milli seconds
                      //Double clicked
                   }
                   LastPressed = DateTime.Now;
             {
        }
