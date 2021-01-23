    public MyApp()
    {
         //USERCONTROL = your control with the CLickFromUserControl event
         this.USERCONTROL.CLickFromUserControl += new EventHandler(MyEventHandlerFunction_CLickFromUserControl);
    }
    
    public void MyEventHandlerFunction_CLickFromUserControl(object sender, EventArgs e)
    {
             //add the value here
    }
