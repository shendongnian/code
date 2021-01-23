    string[] rolesArray;
    
    public void Page_Load()
    {
      if (!IsPostBack)
      {
        // Bind roles to GridView.
    
        try
        {
          rolesArray = Roles.GetRolesForUser();
        }
        catch (HttpException e)
        {
          Msg.Text = "There is no current logged on user.";
          return;
        }
      }
    }
