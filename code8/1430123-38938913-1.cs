    bool buttonLocked;
    System.Timers.Timer t = new System.Timers.Timer(1000); //however many milliseconds
    t.Elapsed += new EventHandler(resetFlag);
    private void button_clicked(object sender, EventArgs e){
        if(!buttonLocked){
           // Handle Click
           buttonLocked= true;
           t.Enabled = true;
        }
    }
   
    private void resetFlag(){
        buttonLocked = false;
        t.Enabled = false;
    }
