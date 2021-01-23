    public event EventHandler CLickFromUserControl;
    private void click_event_on_the_button()
    {
        //Null check makes sure the main page is attached to the event
        if (this.CLickFromUserControl != null)
           this.CLickFromUserControl(new object(), new EventArgs());
    }
