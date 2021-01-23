    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (e.CloseReason == CloseReason.ApplicationExitCall) 
        {
            //Application.Exit();
        }
        else if (e.CloseReason == CloseReason.UserClosing)
        {
            //[X] was pressed
        }
        else 
        {
            //Many other reasons
        }
    }
