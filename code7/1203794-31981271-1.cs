    public void BringToTop()
    {
        //Checks if the method is called from UI thread or not
        if (this.InvokeRequired)
        {
            this.Invoke(new Action(BringToTop));
        }
        else
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            //Keeps the current topmost status of form
            bool top = TopMost;
            //Brings the form to top
            TopMost = true;
            //Set form's topmost status back to whatever it was
            TopMost = top;
        }
    }
