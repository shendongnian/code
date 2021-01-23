    protected void Page_Load(object sender, EventArgs e)
    {
        this.ClientScript.GetPostBackEventReference(this, "arg");
        if (IsPostBack)
        {
            string eventTarget = this.Request["__EVENTTARGET"];
            string eventArgument = this.Request["__EVENTARGUMENT"];
     
            if (eventTarget != String.Empty && eventTarget == "callPostBack")
            {
                if (eventArgument == "inside"){   
                   //do something
                   }
               else if(eventArgument == "outside")
                {
               //do something
               }
           }
        else
        {
           // set the button click
            btnclick.Attributes.Add("onClick", "isIFrame();");
        }
    }
