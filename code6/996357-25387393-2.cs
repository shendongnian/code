    private MyEntities fMyModel = null;
    
    protected MyEntities MyModel
    {
      get
      {
        if (fMyModel == null)
        {
          string connString = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
          fMyModel = new MyEntities(connString);
        }
        return fMyModel;
      }
    } 
