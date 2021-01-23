    private bool close_state=false;    // hold the button state
    
    // method to change the close_state by button click
    private void Button1(object sender, EventArgs e)
    {
        close_state = true;
        // if required you can toggle the close_state using an if statement
    }
    
    // Then on FormClosing event check that property:
    
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (close_state) {// If the button is pressed
            e.Cancel = true; // Cancel form closing
        }
    }
    
