    void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
            BindLists();   
    }
    void BindLists()
    {
        //----------STATUS CHANGE MENU OPTIONS----------
        SEL_StatusChange.Items.Add(NewGroupedListItem("New Hire", "New Hire", "Onboard or Separate"));
        SEL_StatusChange.Items.Add(NewGroupedListItem("Separation", "Separation", "Onboard or Separate"));
        // etc.
    }
