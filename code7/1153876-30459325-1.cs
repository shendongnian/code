    public string sortOrder
    {
          get
          {
               if (!string.IsNullOrEmpty(Convert.ToString(ViewState["sortOrder"])) && Convert.ToString(ViewState["sortOrder"]) == "Desc")
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
