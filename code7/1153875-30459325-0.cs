    public string sortOrder
    {
          get
          {
               if (ViewState["sortOrder"] == "Desc")
               {
                    ViewState["sortOrder"] = "Asc";
               }
               else
               {
                    ViewState["sortOrder"] = "Desc";
               }
    
               return Convert.ToString(ViewState["sortOrder"]);
          }
          set
          {
               ViewState["sortOrder"] = value;
          }
    }
