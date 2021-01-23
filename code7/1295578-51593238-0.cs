    public override void ViewDidLoad()
    {
         Mybutton.AddTarget(ButtonEventHandler, UIControlEvent.TouchUpInside);
    }
    public void ButtonEventHandler(object sender, EventArgs e)
    {
        if(sender==Mybutton)
        {
           //do stuff here
        }
    }
